// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Gov.Lclb.Cllb.Interfaces.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// contactinvoices
    /// </summary>
    public partial class MicrosoftDynamicsCRMcontactinvoices
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMcontactinvoices class.
        /// </summary>
        public MicrosoftDynamicsCRMcontactinvoices()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMcontactinvoices class.
        /// </summary>
        public MicrosoftDynamicsCRMcontactinvoices(string contactinvoiceid = default(string), string contactid = default(string), long? versionnumber = default(long?), string invoiceid = default(string))
        {
            Contactinvoiceid = contactinvoiceid;
            Contactid = contactid;
            Versionnumber = versionnumber;
            Invoiceid = invoiceid;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "contactinvoiceid")]
        public string Contactinvoiceid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "contactid")]
        public string Contactid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "versionnumber")]
        public long? Versionnumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "invoiceid")]
        public string Invoiceid { get; set; }

    }
}
