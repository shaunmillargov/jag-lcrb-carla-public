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
    /// Microsoft.Dynamics.CRM.discount
    /// </summary>
    public partial class MicrosoftDynamicsCRMdiscount
    {
        /// <summary>
        /// Initializes a new instance of the MicrosoftDynamicsCRMdiscount
        /// class.
        /// </summary>
        public MicrosoftDynamicsCRMdiscount()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MicrosoftDynamicsCRMdiscount
        /// class.
        /// </summary>
        public MicrosoftDynamicsCRMdiscount(int? timezoneruleversionnumber = default(int?), decimal? amount = default(decimal?), string _modifiedbyValue = default(string), bool? isamounttype = default(bool?), System.DateTimeOffset? overriddencreatedon = default(System.DateTimeOffset?), string name = default(string), string discountid = default(string), string _discounttypeidValue = default(string), string organizationid = default(string), System.DateTimeOffset? createdon = default(System.DateTimeOffset?), int? importsequencenumber = default(int?), int? utcconversiontimezonecode = default(int?), string _createdbyValue = default(string), decimal? exchangerate = default(decimal?), string _modifiedonbehalfbyValue = default(string), decimal? percentage = default(decimal?), decimal? lowquantity = default(decimal?), decimal? highquantity = default(decimal?), string _createdonbehalfbyValue = default(string), string versionnumber = default(string), decimal? amountBase = default(decimal?), string _transactioncurrencyidValue = default(string), System.DateTimeOffset? modifiedon = default(System.DateTimeOffset?), IList<MicrosoftDynamicsCRMteam> discountTeams = default(IList<MicrosoftDynamicsCRMteam>), IList<MicrosoftDynamicsCRMmailboxtrackingfolder> discountMailboxTrackingFolders = default(IList<MicrosoftDynamicsCRMmailboxtrackingfolder>), IList<MicrosoftDynamicsCRMprincipalobjectattributeaccess> discountPrincipalObjectAttributeAccesses = default(IList<MicrosoftDynamicsCRMprincipalobjectattributeaccess>), IList<MicrosoftDynamicsCRMasyncoperation> discountAsyncOperations = default(IList<MicrosoftDynamicsCRMasyncoperation>), MicrosoftDynamicsCRMsystemuser createdonbehalfby = default(MicrosoftDynamicsCRMsystemuser), MicrosoftDynamicsCRMtransactioncurrency transactioncurrencyid = default(MicrosoftDynamicsCRMtransactioncurrency), IList<MicrosoftDynamicsCRMsyncerror> discountSyncErrors = default(IList<MicrosoftDynamicsCRMsyncerror>), MicrosoftDynamicsCRMsystemuser createdby = default(MicrosoftDynamicsCRMsystemuser), IList<MicrosoftDynamicsCRMprocesssession> discountProcessSessions = default(IList<MicrosoftDynamicsCRMprocesssession>), MicrosoftDynamicsCRMdiscounttype discounttypeid = default(MicrosoftDynamicsCRMdiscounttype), IList<MicrosoftDynamicsCRMbulkdeletefailure> discountBulkDeleteFailures = default(IList<MicrosoftDynamicsCRMbulkdeletefailure>), MicrosoftDynamicsCRMsystemuser modifiedonbehalfby = default(MicrosoftDynamicsCRMsystemuser), MicrosoftDynamicsCRMsystemuser modifiedby = default(MicrosoftDynamicsCRMsystemuser))
        {
            Timezoneruleversionnumber = timezoneruleversionnumber;
            Amount = amount;
            this._modifiedbyValue = _modifiedbyValue;
            Isamounttype = isamounttype;
            Overriddencreatedon = overriddencreatedon;
            Name = name;
            Discountid = discountid;
            this._discounttypeidValue = _discounttypeidValue;
            Organizationid = organizationid;
            Createdon = createdon;
            Importsequencenumber = importsequencenumber;
            Utcconversiontimezonecode = utcconversiontimezonecode;
            this._createdbyValue = _createdbyValue;
            Exchangerate = exchangerate;
            this._modifiedonbehalfbyValue = _modifiedonbehalfbyValue;
            Percentage = percentage;
            Lowquantity = lowquantity;
            Highquantity = highquantity;
            this._createdonbehalfbyValue = _createdonbehalfbyValue;
            Versionnumber = versionnumber;
            AmountBase = amountBase;
            this._transactioncurrencyidValue = _transactioncurrencyidValue;
            Modifiedon = modifiedon;
            DiscountTeams = discountTeams;
            DiscountMailboxTrackingFolders = discountMailboxTrackingFolders;
            DiscountPrincipalObjectAttributeAccesses = discountPrincipalObjectAttributeAccesses;
            DiscountAsyncOperations = discountAsyncOperations;
            Createdonbehalfby = createdonbehalfby;
            Transactioncurrencyid = transactioncurrencyid;
            DiscountSyncErrors = discountSyncErrors;
            Createdby = createdby;
            DiscountProcessSessions = discountProcessSessions;
            Discounttypeid = discounttypeid;
            DiscountBulkDeleteFailures = discountBulkDeleteFailures;
            Modifiedonbehalfby = modifiedonbehalfby;
            Modifiedby = modifiedby;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timezoneruleversionnumber")]
        public int? Timezoneruleversionnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_modifiedby_value")]
        public string _modifiedbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isamounttype")]
        public bool? Isamounttype { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "overriddencreatedon")]
        public System.DateTimeOffset? Overriddencreatedon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "discountid")]
        public string Discountid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_discounttypeid_value")]
        public string _discounttypeidValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "organizationid")]
        public string Organizationid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdon")]
        public System.DateTimeOffset? Createdon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "importsequencenumber")]
        public int? Importsequencenumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "utcconversiontimezonecode")]
        public int? Utcconversiontimezonecode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_createdby_value")]
        public string _createdbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "exchangerate")]
        public decimal? Exchangerate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_modifiedonbehalfby_value")]
        public string _modifiedonbehalfbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "percentage")]
        public decimal? Percentage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lowquantity")]
        public decimal? Lowquantity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "highquantity")]
        public decimal? Highquantity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_createdonbehalfby_value")]
        public string _createdonbehalfbyValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "versionnumber")]
        public string Versionnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "amount_base")]
        public decimal? AmountBase { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "_transactioncurrencyid_value")]
        public string _transactioncurrencyidValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedon")]
        public System.DateTimeOffset? Modifiedon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "discount_Teams")]
        public IList<MicrosoftDynamicsCRMteam> DiscountTeams { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "discount_MailboxTrackingFolders")]
        public IList<MicrosoftDynamicsCRMmailboxtrackingfolder> DiscountMailboxTrackingFolders { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "discount_PrincipalObjectAttributeAccesses")]
        public IList<MicrosoftDynamicsCRMprincipalobjectattributeaccess> DiscountPrincipalObjectAttributeAccesses { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Discount_AsyncOperations")]
        public IList<MicrosoftDynamicsCRMasyncoperation> DiscountAsyncOperations { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdonbehalfby")]
        public MicrosoftDynamicsCRMsystemuser Createdonbehalfby { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "transactioncurrencyid")]
        public MicrosoftDynamicsCRMtransactioncurrency Transactioncurrencyid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Discount_SyncErrors")]
        public IList<MicrosoftDynamicsCRMsyncerror> DiscountSyncErrors { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdby")]
        public MicrosoftDynamicsCRMsystemuser Createdby { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Discount_ProcessSessions")]
        public IList<MicrosoftDynamicsCRMprocesssession> DiscountProcessSessions { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "discounttypeid")]
        public MicrosoftDynamicsCRMdiscounttype Discounttypeid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Discount_BulkDeleteFailures")]
        public IList<MicrosoftDynamicsCRMbulkdeletefailure> DiscountBulkDeleteFailures { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedonbehalfby")]
        public MicrosoftDynamicsCRMsystemuser Modifiedonbehalfby { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedby")]
        public MicrosoftDynamicsCRMsystemuser Modifiedby { get; set; }

    }
}
