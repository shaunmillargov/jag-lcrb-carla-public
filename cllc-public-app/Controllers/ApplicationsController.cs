﻿using Gov.Lclb.Cllb.Interfaces;
using Gov.Lclb.Cllb.Interfaces.Models;
using Gov.Lclb.Cllb.Public.Authentication;
using Gov.Lclb.Cllb.Public.Models;
using Gov.Lclb.Cllb.Public.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf;
using static Gov.Lclb.Cllb.Services.FileManager.FileManager;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Gov.Lclb.Cllb.Public.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Business-User")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;
        private readonly IDynamicsClient _dynamicsClient;
        private readonly IWebHostEnvironment _env;
        private readonly FileManagerClient _fileManagerClient;

        public ApplicationsController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, ILoggerFactory loggerFactory, IDynamicsClient dynamicsClient, FileManagerClient fileClient, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _dynamicsClient = dynamicsClient;
            _logger = loggerFactory.CreateLogger(typeof(ApplicationsController));
            _fileManagerClient = fileClient;
            _env = env;
        }



        /// <summary>
        /// Get a license application by applicant id
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        private List<ViewModels.ApplicationSummary> GetApplicationSummariesByApplicant(string applicantId)
        {
            List<ViewModels.ApplicationSummary> result = new List<ViewModels.ApplicationSummary>();

            IEnumerable<MicrosoftDynamicsCRMadoxioApplication> dynamicsApplicationList = _dynamicsClient.GetApplicationListByApplicant(applicantId);
            if (dynamicsApplicationList != null)
            {
                foreach (MicrosoftDynamicsCRMadoxioApplication dynamicsApplication in dynamicsApplicationList)
                {
                    // hide terminated applications from view.
                    if (dynamicsApplication.Statuscode == null || (dynamicsApplication.Statuscode != (int)AdoxioApplicationStatusCodes.Terminated
                        && dynamicsApplication.Statuscode != (int)AdoxioApplicationStatusCodes.Refused
                        && dynamicsApplication.Statuscode != (int)AdoxioApplicationStatusCodes.Cancelled
                        && dynamicsApplication.Statuscode != (int)AdoxioApplicationStatusCodes.TerminatedAndRefunded))
                    {
                        result.Add(dynamicsApplication.ToSummaryViewModel());
                    }
                }

            }
            return result;
        }

        /// <summary>
        /// Get a license application by applicant id
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        private async Task<List<ViewModels.Application>> GetApplicationsByApplicant(string applicantId)
        {
            List<ViewModels.Application> result = new List<ViewModels.Application>();

            IEnumerable<MicrosoftDynamicsCRMadoxioApplication> dynamicsApplicationList = _dynamicsClient.GetApplicationListByApplicant(applicantId);
            if (dynamicsApplicationList != null)
            {
                foreach (MicrosoftDynamicsCRMadoxioApplication dynamicsApplication in dynamicsApplicationList)
                {
                    // hide terminated applications from view.
                    if (dynamicsApplication.Statuscode == null || (dynamicsApplication.Statuscode != (int)AdoxioApplicationStatusCodes.Terminated
                        && dynamicsApplication.Statuscode != (int)AdoxioApplicationStatusCodes.Refused
                        && dynamicsApplication.Statuscode != (int)AdoxioApplicationStatusCodes.Cancelled
                        && dynamicsApplication.Statuscode != (int)AdoxioApplicationStatusCodes.TerminatedAndRefunded))
                    {
                        result.Add(await dynamicsApplication.ToViewModel(_dynamicsClient, _logger));
                    }
                }

                // second pass to determine if transfer or location change is in progress.

                foreach (var item in result)
                {
                    if (item.LicenseType == "Cannabis Retail Store" && item.ApplicationStatus == AdoxioApplicationStatusCodes.Approved
                        && item.AssignedLicence != null && item.AssignedLicence.expiryDate > DateTime.Now
                        )
                    {
                        // determine if there is a transfer in progress.
                        item.IsLocationChangeInProgress = FindRelatedApplication(result, item, "CRS Location Change");
                        // item.isTransferInProgress = FindRelatedApplication(result, item, "CRS Transfer of Ownership");
                    }
                }

            }
            return result;
        }

        bool FindRelatedApplication(List<ViewModels.Application> applicationList, ViewModels.Application application, string licenseType)
        {
            bool result = false;
            foreach (var item in applicationList)
            {
                if (item.LicenseType == licenseType && item.AssignedLicence != null && item.AssignedLicence.id == application.AssignedLicence.id)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }


        /// <summary>
        /// Gets the number of active licences
        /// </summary>
        /// <param name="licenceeId"></param>
        /// <returns></returns>
        private int GetApprovedLicenceCountByApplicant(string licenceeId)
        {

            var result = 0;
            List<ApplicationLicenseSummary> licenseSummaryList = new List<ApplicationLicenseSummary>();
            IEnumerable<MicrosoftDynamicsCRMadoxioLicences> licences = null;
            if (!string.IsNullOrEmpty(licenceeId))
            {
                var filter = $"_adoxio_licencee_value eq {licenceeId}";
                filter += $" and statuscode eq { (int)LicenceStatusCodes.Active}";
                var expand = new List<string> { "adoxio_LicenceType" };
                try
                {
                    result = _dynamicsClient.Licenceses.Get(filter: filter, expand: expand).Value
                    .Count(licence => licence.AdoxioLicenceType.AdoxioName == "Cannabis Retail Store");
                }
                catch (HttpOperationException)
                {
                    result = 0;
                }

            }

            return result;
        }


        /// <summary>
        /// Gets the number of applications that are submitted
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        private int GetSubmittedCountByApplicant(string applicantId)
        {

            var result = 0;
            if (!string.IsNullOrEmpty(applicantId))
            {
                var filter = $"_adoxio_applicant_value eq {applicantId} and adoxio_paymentrecieved eq true and statuscode ne {(int)AdoxioApplicationStatusCodes.Terminated}";                
                filter += $" and statuscode ne {(int)AdoxioApplicationStatusCodes.Cancelled}";
                filter += $" and statuscode ne {(int)AdoxioApplicationStatusCodes.Approved}";
                filter += $" and statuscode ne {(int)AdoxioApplicationStatusCodes.Refused}";
                filter += $" and statuscode ne {(int)AdoxioApplicationStatusCodes.TerminatedAndRefunded}";

                var applicationType = _dynamicsClient.GetApplicationTypeByName("Cannabis Retail Store");
                if (applicationType != null)
                {
                    filter += $" and _adoxio_applicationtypeid_value eq {applicationType.AdoxioApplicationtypeid} ";
                }

                try
                {
                    result = _dynamicsClient.Applications.Get(filter: filter).Value.Count;
                }
                catch (HttpOperationException)
                {
                    result = 0;
                }
            }
            return result;
        }

        /// <summary>
        /// GET all applications in Dynamics. Optional parameter for applicant ID. Or all applications if the applicantId is null
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<JsonResult> GetDynamicsApplications(string applicantId)
        {
            List<ViewModels.Application> adoxioApplications = await GetApplicationsByApplicant(applicantId);
            return new JsonResult(adoxioApplications);
        }


        /// GET all applications in Dynamics for the current user
        [HttpGet("current")]
        public JsonResult GetCurrentUserApplications()
        {
            // get the current user.
            string temp = _httpContextAccessor.HttpContext.Session.GetString("UserSettings");
            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(temp);

            // GET all applications in Dynamics by applicant using the account Id assigned to the user logged in
            List<ViewModels.ApplicationSummary> adoxioApplications = GetApplicationSummariesByApplicant(userSettings.AccountId);
            return new JsonResult(adoxioApplications);
        }

        /// GET all applications in Dynamics for the current user
        [HttpGet("current/by-type/{applicationType}")]
        public JsonResult GetCurrentUserApplicationsByType(string applicationType)
        {
            var results = new List<ApplicationSummary>();
            // get the current user.
            string temp = _httpContextAccessor.HttpContext.Session.GetString("UserSettings");
            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(temp);

            var filter = $"_adoxio_applicant_value eq {userSettings.AccountId}";
            var appType = _dynamicsClient.GetApplicationTypeByName("Licensee Changes");
            if (appType != null)
            {
                filter += $" and _adoxio_applicationtypeid_value eq {appType.AdoxioApplicationtypeid} ";
            }

            try
            {
                var applications = _dynamicsClient.Applications.Get(filter: filter).Value.ToList();
                if (applications != null)
                {
                    foreach (MicrosoftDynamicsCRMadoxioApplication dynamicsApplication in applications)
                    {
                        results.Add(dynamicsApplication.ToSummaryViewModel());
                    }
                }

            }
            catch (HttpOperationException e)
            {
                _logger.LogError(e, "Error getting licensee application");
                throw;
            }
            return new JsonResult(results);
        }

        
        /// GET all applications in Dynamics for the current user
        [HttpGet("ongoing-licensee-application-id")]
        public IActionResult GetOngoingLicenseeApplicationId()
        {
            // get the current user.
            string temp = _httpContextAccessor.HttpContext.Session.GetString("UserSettings");
            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(temp);
            IActionResult result = null;

            // GET all licensee change applications in Dynamics by applicant using the account Id assigned to the user logged in
            var filter = $"_adoxio_applicant_value eq {userSettings.AccountId} and adoxio_paymentrecieved ne true and statuscode ne {(int)AdoxioApplicationStatusCodes.Terminated}";
            filter += $" and adoxio_isapplicationcomplete ne 1";
            filter += $" and statuscode ne {(int)AdoxioApplicationStatusCodes.Cancelled}";
            filter += $" and statuscode ne {(int)AdoxioApplicationStatusCodes.Approved}";
            filter += $" and statuscode ne {(int)AdoxioApplicationStatusCodes.Refused}";
            filter += $" and statuscode ne {(int)AdoxioApplicationStatusCodes.TerminatedAndRefunded}";

            var applicationType = _dynamicsClient.GetApplicationTypeByName("Licensee Changes");
            if (applicationType != null)
            {
                filter += $" and _adoxio_applicationtypeid_value eq {applicationType.AdoxioApplicationtypeid} ";
            }

            try
            {
                var applications = _dynamicsClient.Applications.Get(filter: filter).Value.OrderBy(app => app.Createdon);
                var application = applications.FirstOrDefault();
                if (application != null)
                {
                    result = new JsonResult(application.AdoxioApplicationid);
                }
                else
                {
                    result = new JsonResult(null);
                }
            }
            catch (HttpOperationException e)
            {
                _logger.LogError(e, "Error getting licensee application");
                throw;
            }
            return result;
        }

        /// GET submitted applications in Dynamics for the current user
        [HttpGet("current/submitted-count")]
        public JsonResult GetCountForCurrentUserSubmittedApplications()
        {
            // get the current user.
            string temp = _httpContextAccessor.HttpContext.Session.GetString("UserSettings");
            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(temp);

            // GET all applications in Dynamics by applicant using the account Id assigned to the user logged in
            var count = GetSubmittedCountByApplicant(userSettings.AccountId);
            count += GetApprovedLicenceCountByApplicant(userSettings.AccountId);
            return new JsonResult(count);
        }

        /// <summary>
        /// GET an Application by ID
        /// </summary>
        /// <param name="id">GUID of the Application to get</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplication(string id)
        {
            // get the current user.
            string temp = _httpContextAccessor.HttpContext.Session.GetString("UserSettings");
            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(temp);

            _logger.LogDebug("Application id = " + id);
            _logger.LogDebug("User id = " + userSettings.AccountId);

            ViewModels.Application result = null;
            var dynamicsApplication = await _dynamicsClient.GetApplicationByIdWithChildren(Guid.Parse(id));
            if (dynamicsApplication == null)
            {
                return NotFound();
            }
            else
            {
                if (!CurrentUserHasAccessToApplicationOwnedBy(dynamicsApplication._adoxioApplicantValue))
                {
                    return new NotFoundResult();
                }
                result = await dynamicsApplication.ToViewModel(_dynamicsClient, _logger);
            }




            if (dynamicsApplication.AdoxioApplicationSharePointDocumentLocations.Count == 0)
            {
                await initializeSharepoint(dynamicsApplication);
            }

            return new JsonResult(result);
        }

        private string GetApplicationFolderName(MicrosoftDynamicsCRMadoxioApplication application)
        {
            string applicationIdCleaned = application.AdoxioApplicationid.ToString().ToUpper().Replace("-", "");
            string folderName = $"{application.AdoxioJobnumber}_{applicationIdCleaned}";
            return folderName;
        }

        /// <summary>
        /// Get a document location by reference
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <returns></returns>
        private string GetDocumentLocationReferenceByRelativeURL(string relativeUrl)
        {
            string result = null;
            string sanitized = relativeUrl.Replace("'", "''");
            // first see if one exists.
            var locations = _dynamicsClient.Sharepointdocumentlocations.Get(filter: "relativeurl eq '" + sanitized + "'");

            var location = locations.Value.FirstOrDefault();

            if (location == null)
            {
                var parentSite = _dynamicsClient.Sharepointsites.Get().Value.FirstOrDefault();
                var parentSiteRef = _dynamicsClient.GetEntityURI("sharepointsites", parentSite.Sharepointsiteid);
                MicrosoftDynamicsCRMsharepointdocumentlocation newRecord = new MicrosoftDynamicsCRMsharepointdocumentlocation()
                {
                    Relativeurl = relativeUrl,
                    Name = "Application",
                    ParentSiteODataBind = parentSiteRef
                };
                // create a new document location.
                try
                {
                    location = _dynamicsClient.Sharepointdocumentlocations.Create(newRecord);
                }
                catch (HttpOperationException httpOperationException)
                {
                    _logger.LogError(httpOperationException, "Error creating document location");
                }
            }

            if (location != null)
            {
                result = location.Sharepointdocumentlocationid;
            }

            return result;
        }


        /// <summary>
        /// Create an Application in Dynamics (POST)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> CreateApplication([FromBody] ViewModels.Application item)
        {

            // for association with current user
            string userJson = _httpContextAccessor.HttpContext.Session.GetString("UserSettings");
            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(userJson);
            int count = GetSubmittedCountByApplicant(userSettings.AccountId);
            count += GetApprovedLicenceCountByApplicant(userSettings.AccountId);

            if (count >= 8 && item.ApplicationType.Name == "Cannabis Retail Store")
            {
                return BadRequest("8 applications have already been submitted. Can not create more");
            }
            MicrosoftDynamicsCRMadoxioApplication adoxioApplication = new MicrosoftDynamicsCRMadoxioApplication();
            // copy received values to Dynamics Application
            adoxioApplication.CopyValues(item);
            adoxioApplication.AdoxioApplicanttype = (int?)item.ApplicantType;
            try
            {
                // set license type relationship 
                if (!string.IsNullOrEmpty(item.LicenseType))
                {
                    var adoxioLicencetype = _dynamicsClient.GetAdoxioLicencetypeByName(item.LicenseType);
                    adoxioApplication.AdoxioLicenceTypeODataBind = _dynamicsClient.GetEntityURI("adoxio_licencetypes", adoxioLicencetype.AdoxioLicencetypeid);
                }

                // set account relationship
                adoxioApplication.AdoxioApplicantODataBind = _dynamicsClient.GetEntityURI("accounts", userSettings.AccountId);

                // set application type relationship 
                var applicationType = _dynamicsClient.GetApplicationTypeByName(item.ApplicationType.Name);
                adoxioApplication.AdoxioApplicationTypeIdODataBind = _dynamicsClient.GetEntityURI("adoxio_applicationtypes", applicationType.AdoxioApplicationtypeid);

                if (item.ApplicationType.Name == "Marketing")
                {
                    // create tiedhouse relationship
                    adoxioApplication.AdoxioApplicationAdoxioTiedhouseconnectionApplication = new List<MicrosoftDynamicsCRMadoxioTiedhouseconnection>{
                            new MicrosoftDynamicsCRMadoxioTiedhouseconnection()
                            {
                                AdoxioConnectiontype = (int?)TiedHouseConnectionType.Marketer
                            }
                        };
                }

                // create application
                adoxioApplication = _dynamicsClient.Applications.Create(adoxioApplication);
            }
            catch (HttpOperationException httpOperationException)
            {
                string applicationId = _dynamicsClient.GetCreatedRecord(httpOperationException, null);
                if (!string.IsNullOrEmpty(applicationId) && Guid.TryParse(applicationId, out Guid applicationGuid))
                {
                    adoxioApplication = await _dynamicsClient.GetApplicationById(applicationGuid);
                }
                else
                {

                    _logger.LogError(httpOperationException, "Error creating application");
                    // fail if we can't create.
                    throw (httpOperationException);
                }

            }

            // in case the job number is not there, try getting the record from the server.
            if (adoxioApplication.AdoxioJobnumber == null)
            {
                _logger.LogDebug("AdoxioJobnumber is null, fetching record again.");
                Guid id = Guid.Parse(adoxioApplication.AdoxioApplicationid);
                adoxioApplication = await _dynamicsClient.GetApplicationById(id);
            }

            if (adoxioApplication.AdoxioJobnumber == null)
            {
                _logger.LogDebug("Unable to get the Job Number for the Application.");
                throw new Exception("Error creating Licence Application.");
            }

            await initializeSharepoint(adoxioApplication);

            return new JsonResult(await adoxioApplication.ToViewModel(_dynamicsClient, _logger));

        }


        [HttpPost("covid")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCovidApplication([FromBody] ViewModels.CovidApplication item)
        {
            // check to see if the feature is on.
            if (string.IsNullOrEmpty(_configuration["FEATURE_COVID_APPLICATION"]))
            {
                return BadRequest();
            }



            var adoxioApplication = new MicrosoftDynamicsCRMadoxioApplication();
            adoxioApplication.CopyValuesForCovidApplication(item);

            adoxioApplication.AdoxioApplicanttype = (int?)845280000;  // private corp - change to public user.

            // set license type relationship 
            if (!string.IsNullOrEmpty(item.LicenceType))
            {
                var adoxioLicencetype = _dynamicsClient.GetAdoxioLicencetypeByName(item.LicenceType);
                adoxioApplication.AdoxioLicenceTypeODataBind = _dynamicsClient.GetEntityURI("adoxio_licencetypes", adoxioLicencetype.AdoxioLicencetypeid);
            }

            // set application type relationship 
            var applicationType = _dynamicsClient.GetApplicationTypeByName("Temporary Extension of Licensed Area");
            adoxioApplication.AdoxioApplicationTypeIdODataBind = _dynamicsClient.GetEntityURI("adoxio_applicationtypes", applicationType.AdoxioApplicationtypeid);

            try
            {
                // create application
                adoxioApplication = _dynamicsClient.Applications.Create(adoxioApplication);
                _logger.LogInformation($"CREATED COVID APPLICATION {adoxioApplication.AdoxioApplicationid}");
            }
            catch (HttpOperationException httpOperationException)
            {
                string applicationId = _dynamicsClient.GetCreatedRecord(httpOperationException, null);
                if (!string.IsNullOrEmpty(applicationId) && Guid.TryParse(applicationId, out Guid applicationGuid))
                {
                    adoxioApplication = await _dynamicsClient.GetApplicationById(applicationGuid);
                }
                else
                {

                    _logger.LogError(httpOperationException, "Error creating COVID application");
                    // fail if we can't create.
                    throw (httpOperationException);
                }

            }

            await initializeSharepoint(adoxioApplication);

            return new JsonResult(await adoxioApplication.ToCovidViewModel(_dynamicsClient, _logger));
        }
        private async Task initializeSharepoint(MicrosoftDynamicsCRMadoxioApplication adoxioApplication)
        {
            // create a SharePointDocumentLocation link
            string folderName = GetApplicationFolderName(adoxioApplication);
            string name = adoxioApplication.AdoxioJobnumber + " Files";

            _fileManagerClient.CreateFolderIfNotExist(_logger, ApplicationDocumentUrlTitle, folderName);

            // Create the SharePointDocumentLocation entity
            MicrosoftDynamicsCRMsharepointdocumentlocation mdcsdl = new MicrosoftDynamicsCRMsharepointdocumentlocation()
            {
                Relativeurl = folderName,
                Description = "Application Files",
                Name = name
            };


            try
            {
                mdcsdl = _dynamicsClient.Sharepointdocumentlocations.Create(mdcsdl);
            }
            catch (HttpOperationException httpOperationException)
            {
                string mdcsdlId = _dynamicsClient.GetCreatedRecord(httpOperationException, null);
                if (!string.IsNullOrEmpty(mdcsdlId))
                {
                    mdcsdl.Sharepointdocumentlocationid = mdcsdlId;
                }
                else
                {
                    _logger.LogError(httpOperationException, "Error creating SharepointDocumentLocation");
                    mdcsdl = null;
                }

            }
            if (mdcsdl != null)
            {
                // add a regardingobjectid.
                string applicationReference = _dynamicsClient.GetEntityURI("adoxio_applications", adoxioApplication.AdoxioApplicationid);
                var patchSharePointDocumentLocation = new MicrosoftDynamicsCRMsharepointdocumentlocation();
                patchSharePointDocumentLocation.RegardingobjectidAdoxioApplicationODataBind = applicationReference;
                // set the parent document library.
                string parentDocumentLibraryReference = GetDocumentLocationReferenceByRelativeURL("adoxio_application");
                patchSharePointDocumentLocation.ParentsiteorlocationSharepointdocumentlocationODataBind = _dynamicsClient.GetEntityURI("sharepointdocumentlocations", parentDocumentLibraryReference);

                try
                {
                    _dynamicsClient.Sharepointdocumentlocations.Update(mdcsdl.Sharepointdocumentlocationid, patchSharePointDocumentLocation);
                }
                catch (HttpOperationException httpOperationException)
                {
                    _logger.LogError(httpOperationException, "Error adding reference SharepointDocumentLocation to application");
                }

                string sharePointLocationData = _dynamicsClient.GetEntityURI("sharepointdocumentlocations", mdcsdl.Sharepointdocumentlocationid);
                // update the sharePointLocationData.
                Odataid oDataId = new Odataid()
                {
                    OdataidProperty = sharePointLocationData
                };
                try
                {
                    _dynamicsClient.Applications.AddReference(adoxioApplication.AdoxioApplicationid, "adoxio_application_SharePointDocumentLocations", oDataId);
                }
                catch (HttpOperationException httpOperationException)
                {
                    _logger.LogError(httpOperationException, "Error adding reference to SharepointDocumentLocation");
                }
            }
        }

        /// <summary>
        /// Update a Dynamics Application (PUT)
        /// </summary>
        /// <param name="item"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication([FromBody] ViewModels.Application item, string id)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            // for association with current user
            string userJson = _httpContextAccessor.HttpContext.Session.GetString("UserSettings");
            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(userJson);


            //Prepare application for update
            Guid adoxio_applicationId = new Guid(id);
            MicrosoftDynamicsCRMadoxioApplication adoxioApplication = await _dynamicsClient.GetApplicationById(adoxio_applicationId);

            if (!CurrentUserHasAccessToApplicationOwnedBy(adoxioApplication._adoxioApplicantValue))
            {
                return new NotFoundResult();
            }

            adoxioApplication = new MicrosoftDynamicsCRMadoxioApplication();

            adoxioApplication.CopyValues(item);

            try
            {
                // Indigenous nation association
                if (!string.IsNullOrEmpty(item.IndigenousNationId))
                {
                    adoxioApplication.AdoxioLocalgovindigenousnationidODataBind = _dynamicsClient.GetEntityURI("adoxio_localgovindigenousnations", item.IndigenousNationId);
                }
                else
                {
                    //remove reference
                    await _dynamicsClient.Applications.DeleteReferenceAsync(item.Id, "adoxio_localgovindigenousnationid");
                }

                _dynamicsClient.Applications.Update(id, adoxioApplication);
            }
            catch (HttpOperationException httpOperationException)
            {
                _logger.LogError(httpOperationException, "Error updating application");
                // fail if we can't create.
                throw (httpOperationException);
            }

            adoxioApplication = await _dynamicsClient.GetApplicationById(adoxio_applicationId);

            return new JsonResult(await adoxioApplication.ToViewModel(_dynamicsClient, _logger));
        }

        /// <summary>
        /// Cancel an Application.  Using a HTTP Post to avoid Siteminder issues with DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> CancelApplication(string id)
        {
            // get the application.
            Guid adoxio_applicationid = new Guid(id);

            MicrosoftDynamicsCRMadoxioApplication adoxioApplication = await _dynamicsClient.GetApplicationById(adoxio_applicationid);
            if (adoxioApplication == null)
            {
                return new NotFoundResult();
            }

            if (!CurrentUserHasAccessToApplicationOwnedBy(adoxioApplication._adoxioApplicantValue))
            {
                return new NotFoundResult();
            }

            // set the status to Terminated.
            MicrosoftDynamicsCRMadoxioApplication patchRecord = new MicrosoftDynamicsCRMadoxioApplication()
            {
                //StatusCodeODataBind = ((int)AdoxioApplicationStatusCodes.Terminated).ToString()
                Statuscode = (int)AdoxioApplicationStatusCodes.Terminated
            };

            try
            {
                _dynamicsClient.Applications.Update(id, patchRecord);
            }
            catch (HttpOperationException httpOperationException)
            {
                _logger.LogError(httpOperationException, "Error cancelling application");
                // fail if we can't create.
                throw (httpOperationException);
            }


            return NoContent(); // 204
        }

        /// <summary>
        /// Process an application.  Only useful for automated testing.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/process")]
        public async Task<IActionResult> ProcessApplication(string id)
        {
            if (_env.IsProduction()) return BadRequest("This API is not available outside a development environment.");


            // get the current user.
            string sessionSettings = _httpContextAccessor.HttpContext.Session.GetString("UserSettings");
            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(sessionSettings);


            // query the Dynamics system to get the account record.
            if (userSettings.AccountId != null && !userSettings.IsNewUserRegistration && userSettings.AccountId.Length > 0)
            {

                // call the bpf to process the application.
                try
                {
                    // this needs to be the guid for the published workflow.
                    await _dynamicsClient.Workflows.ExecuteWorkflowWithHttpMessagesAsync("0a78e6dc-8d62-480f-909f-c104051cf467", id);
                    return Ok("OK");
                }
                catch (HttpOperationException httpOperationException)
                {
                    string error = httpOperationException.Response.Content;
                    return BadRequest(error);
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            else
            {
                return BadRequest("This API is not available to an unregistered user.");
            }
        }

        /// <summary>
        /// Delete an Application.  Using a HTTP Post to avoid Siteminder issues with DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}/delete")]
        public async Task<IActionResult> DeleteApplication(string id)
        {
            // get the application.
            Guid adoxio_applicationid = new Guid(id);

            MicrosoftDynamicsCRMadoxioApplication adoxioApplication = await _dynamicsClient.GetApplicationById(adoxio_applicationid);
            if (adoxioApplication == null)
            {
                return new NotFoundResult();
            }

            if (!CurrentUserHasAccessToApplicationOwnedBy(adoxioApplication._adoxioApplicantValue))
            {
                return new NotFoundResult();
            }


            await _dynamicsClient.Applications.DeleteAsync(adoxio_applicationid.ToString());

            return NoContent(); // 204
        }

        [HttpPost("{id}/covidDelete")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteCovidApplication(string id)
        {
            if (_env.IsProduction()) return BadRequest("This API is not available outside a development environment.");

            // get the application.
            Guid adoxio_applicationid = new Guid(id);

            MicrosoftDynamicsCRMadoxioApplication adoxioApplication = await _dynamicsClient.GetApplicationById(adoxio_applicationid);
            if (adoxioApplication == null)
            {
                return new NotFoundResult();
            }


            await _dynamicsClient.Applications.DeleteAsync(adoxio_applicationid.ToString());

            return NoContent(); // 204
        }

        /// <summary>
        /// Verify whether currently logged in user has access to this account id
        /// </summary>
        /// <returns>boolean</returns>
        private bool CurrentUserHasAccessToApplicationOwnedBy(string accountId)
        {
            // get the current user.
            string temp = _httpContextAccessor.HttpContext.Session.GetString("UserSettings");
            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(temp);

            // For now, check if the account id matches the user's account.
            // TODO there may be some account relationships in the future
            if (userSettings.AccountId != null && userSettings.AccountId.Length > 0)
            {
                return userSettings.AccountId == accountId;
            }

            // if current user doesn't have an account they are probably not logged in
            return false;
        }
    }
}
