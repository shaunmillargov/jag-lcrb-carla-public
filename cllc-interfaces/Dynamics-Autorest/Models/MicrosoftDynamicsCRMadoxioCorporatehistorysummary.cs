// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Gov.Lclb.Cllb.Interfaces.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Microsoft.Dynamics.CRM.adoxio_corporatehistorysummary
    /// </summary>
    public partial class MicrosoftDynamicsCRMadoxioCorporatehistorysummary
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMadoxioCorporatehistorysummary class.
        /// </summary>
        public MicrosoftDynamicsCRMadoxioCorporatehistorysummary()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMadoxioCorporatehistorysummary class.
        /// </summary>
        public MicrosoftDynamicsCRMadoxioCorporatehistorysummary(string _modifiedonbehalfbyValue = default(string), int? adoxioSecuritystatus = default(int?), string _createdonbehalfbyValue = default(string), string adoxioEstablishmentparcelid = default(string), System.DateTimeOffset? adoxioCompletedon = default(System.DateTimeOffset?), int? statecode = default(int?), string adoxioName = default(string), string _owninguserValue = default(string), string adoxioCorporatehistorysummaryid = default(string), string _modifiedbyValue = default(string), string _createdbyValue = default(string), int? utcconversiontimezonecode = default(int?), int? importsequencenumber = default(int?), string adoxioBcregistriesnumber = default(string), string _adoxioApplicationidValue = default(string), string versionnumber = default(string), string _owningteamValue = default(string), string _owneridValue = default(string), int? timezoneruleversionnumber = default(int?), string adoxioLcrbbusinessjobnumber = default(string), System.DateTimeOffset? createdon = default(System.DateTimeOffset?), int? statuscode = default(int?), System.DateTimeOffset? overriddencreatedon = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedon = default(System.DateTimeOffset?), string _adoxioApplicantidValue = default(string), string _owningbusinessunitValue = default(string), MicrosoftDynamicsCRMsystemuser createdbyname = default(MicrosoftDynamicsCRMsystemuser), MicrosoftDynamicsCRMsystemuser createdonbehalfbyname = default(MicrosoftDynamicsCRMsystemuser), MicrosoftDynamicsCRMsystemuser modifiedbyname = default(MicrosoftDynamicsCRMsystemuser), MicrosoftDynamicsCRMsystemuser modifiedonbehalfbyname = default(MicrosoftDynamicsCRMsystemuser), MicrosoftDynamicsCRMsystemuser owninguser = default(MicrosoftDynamicsCRMsystemuser), MicrosoftDynamicsCRMteam owningteam = default(MicrosoftDynamicsCRMteam), MicrosoftDynamicsCRMprincipal ownerid = default(MicrosoftDynamicsCRMprincipal), MicrosoftDynamicsCRMbusinessunit owningbusinessunit = default(MicrosoftDynamicsCRMbusinessunit), IList<MicrosoftDynamicsCRMsyncerror> adoxioCorporatehistorysummarySyncErrors = default(IList<MicrosoftDynamicsCRMsyncerror>), IList<MicrosoftDynamicsCRMduplicaterecord> adoxioCorporatehistorysummaryDuplicateMatchingRecord = default(IList<MicrosoftDynamicsCRMduplicaterecord>), IList<MicrosoftDynamicsCRMduplicaterecord> adoxioCorporatehistorysummaryDuplicateBaseRecord = default(IList<MicrosoftDynamicsCRMduplicaterecord>), IList<MicrosoftDynamicsCRMasyncoperation> adoxioCorporatehistorysummaryAsyncOperations = default(IList<MicrosoftDynamicsCRMasyncoperation>), IList<MicrosoftDynamicsCRMmailboxtrackingfolder> adoxioCorporatehistorysummaryMailboxTrackingFolders = default(IList<MicrosoftDynamicsCRMmailboxtrackingfolder>), IList<MicrosoftDynamicsCRMprocesssession> adoxioCorporatehistorysummaryProcessSession = default(IList<MicrosoftDynamicsCRMprocesssession>), IList<MicrosoftDynamicsCRMbulkdeletefailure> adoxioCorporatehistorysummaryBulkDeleteFailures = default(IList<MicrosoftDynamicsCRMbulkdeletefailure>), IList<MicrosoftDynamicsCRMprincipalobjectattributeaccess> adoxioCorporatehistorysummaryPrincipalObjectAttributeAccesses = default(IList<MicrosoftDynamicsCRMprincipalobjectattributeaccess>), MicrosoftDynamicsCRMaccount adoxioApplicantId = default(MicrosoftDynamicsCRMaccount), MicrosoftDynamicsCRMadoxioApplication adoxioApplicationId = default(MicrosoftDynamicsCRMadoxioApplication))
        {
            this._modifiedonbehalfbyValue = _modifiedonbehalfbyValue;
            AdoxioSecuritystatus = adoxioSecuritystatus;
            this._createdonbehalfbyValue = _createdonbehalfbyValue;
            AdoxioEstablishmentparcelid = adoxioEstablishmentparcelid;
            AdoxioCompletedon = adoxioCompletedon;
            Statecode = statecode;
            AdoxioName = adoxioName;
            this._owninguserValue = _owninguserValue;
            AdoxioCorporatehistorysummaryid = adoxioCorporatehistorysummaryid;
            this._modifiedbyValue = _modifiedbyValue;
            this._createdbyValue = _createdbyValue;
            Utcconversiontimezonecode = utcconversiontimezonecode;
            Importsequencenumber = importsequencenumber;
            AdoxioBcregistriesnumber = adoxioBcregistriesnumber;
            this._adoxioApplicationidValue = _adoxioApplicationidValue;
            Versionnumber = versionnumber;
            this._owningteamValue = _owningteamValue;
            this._owneridValue = _owneridValue;
            Timezoneruleversionnumber = timezoneruleversionnumber;
            AdoxioLcrbbusinessjobnumber = adoxioLcrbbusinessjobnumber;
            Createdon = createdon;
            Statuscode = statuscode;
            Overriddencreatedon = overriddencreatedon;
            Modifiedon = modifiedon;
            this._adoxioApplicantidValue = _adoxioApplicantidValue;
            this._owningbusinessunitValue = _owningbusinessunitValue;
            Createdbyname = createdbyname;
            Createdonbehalfbyname = createdonbehalfbyname;
            Modifiedbyname = modifiedbyname;
            Modifiedonbehalfbyname = modifiedonbehalfbyname;
            Owninguser = owninguser;
            Owningteam = owningteam;
            Ownerid = ownerid;
            Owningbusinessunit = owningbusinessunit;
            AdoxioCorporatehistorysummarySyncErrors = adoxioCorporatehistorysummarySyncErrors;
            AdoxioCorporatehistorysummaryDuplicateMatchingRecord = adoxioCorporatehistorysummaryDuplicateMatchingRecord;
            AdoxioCorporatehistorysummaryDuplicateBaseRecord = adoxioCorporatehistorysummaryDuplicateBaseRecord;
            AdoxioCorporatehistorysummaryAsyncOperations = adoxioCorporatehistorysummaryAsyncOperations;
            AdoxioCorporatehistorysummaryMailboxTrackingFolders = adoxioCorporatehistorysummaryMailboxTrackingFolders;
            AdoxioCorporatehistorysummaryProcessSession = adoxioCorporatehistorysummaryProcessSession;
            AdoxioCorporatehistorysummaryBulkDeleteFailures = adoxioCorporatehistorysummaryBulkDeleteFailures;
            AdoxioCorporatehistorysummaryPrincipalObjectAttributeAccesses = adoxioCorporatehistorysummaryPrincipalObjectAttributeAccesses;
            AdoxioApplicantId = adoxioApplicantId;
            AdoxioApplicationId = adoxioApplicationId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_modifiedonbehalfby_value")]
        public string _modifiedonbehalfbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_securitystatus")]
        public int? AdoxioSecuritystatus { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_createdonbehalfby_value")]
        public string _createdonbehalfbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_establishmentparcelid")]
        public string AdoxioEstablishmentparcelid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_completedon")]
        public System.DateTimeOffset? AdoxioCompletedon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "statecode")]
        public int? Statecode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_name")]
        public string AdoxioName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_owninguser_value")]
        public string _owninguserValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_corporatehistorysummaryid")]
        public string AdoxioCorporatehistorysummaryid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_modifiedby_value")]
        public string _modifiedbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_createdby_value")]
        public string _createdbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "utcconversiontimezonecode")]
        public int? Utcconversiontimezonecode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "importsequencenumber")]
        public int? Importsequencenumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_bcregistriesnumber")]
        public string AdoxioBcregistriesnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_adoxio_applicationid_value")]
        public string _adoxioApplicationidValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "versionnumber")]
        public string Versionnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_owningteam_value")]
        public string _owningteamValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_ownerid_value")]
        public string _owneridValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timezoneruleversionnumber")]
        public int? Timezoneruleversionnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_lcrbbusinessjobnumber")]
        public string AdoxioLcrbbusinessjobnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdon")]
        public System.DateTimeOffset? Createdon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "statuscode")]
        public int? Statuscode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "overriddencreatedon")]
        public System.DateTimeOffset? Overriddencreatedon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedon")]
        public System.DateTimeOffset? Modifiedon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_adoxio_applicantid_value")]
        public string _adoxioApplicantidValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_owningbusinessunit_value")]
        public string _owningbusinessunitValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdbyname")]
        public MicrosoftDynamicsCRMsystemuser Createdbyname { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdonbehalfbyname")]
        public MicrosoftDynamicsCRMsystemuser Createdonbehalfbyname { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedbyname")]
        public MicrosoftDynamicsCRMsystemuser Modifiedbyname { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedonbehalfbyname")]
        public MicrosoftDynamicsCRMsystemuser Modifiedonbehalfbyname { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "owninguser")]
        public MicrosoftDynamicsCRMsystemuser Owninguser { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "owningteam")]
        public MicrosoftDynamicsCRMteam Owningteam { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ownerid")]
        public MicrosoftDynamicsCRMprincipal Ownerid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "owningbusinessunit")]
        public MicrosoftDynamicsCRMbusinessunit Owningbusinessunit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_corporatehistorysummary_SyncErrors")]
        public IList<MicrosoftDynamicsCRMsyncerror> AdoxioCorporatehistorysummarySyncErrors { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_corporatehistorysummary_DuplicateMatchingRecord")]
        public IList<MicrosoftDynamicsCRMduplicaterecord> AdoxioCorporatehistorysummaryDuplicateMatchingRecord { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_corporatehistorysummary_DuplicateBaseRecord")]
        public IList<MicrosoftDynamicsCRMduplicaterecord> AdoxioCorporatehistorysummaryDuplicateBaseRecord { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_corporatehistorysummary_AsyncOperations")]
        public IList<MicrosoftDynamicsCRMasyncoperation> AdoxioCorporatehistorysummaryAsyncOperations { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_corporatehistorysummary_MailboxTrackingFolders")]
        public IList<MicrosoftDynamicsCRMmailboxtrackingfolder> AdoxioCorporatehistorysummaryMailboxTrackingFolders { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_corporatehistorysummary_ProcessSession")]
        public IList<MicrosoftDynamicsCRMprocesssession> AdoxioCorporatehistorysummaryProcessSession { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_corporatehistorysummary_BulkDeleteFailures")]
        public IList<MicrosoftDynamicsCRMbulkdeletefailure> AdoxioCorporatehistorysummaryBulkDeleteFailures { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_corporatehistorysummary_PrincipalObjectAttributeAccesses")]
        public IList<MicrosoftDynamicsCRMprincipalobjectattributeaccess> AdoxioCorporatehistorysummaryPrincipalObjectAttributeAccesses { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_ApplicantId")]
        public MicrosoftDynamicsCRMaccount AdoxioApplicantId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "adoxio_ApplicationId")]
        public MicrosoftDynamicsCRMadoxioApplication AdoxioApplicationId { get; set; }

    }
}
