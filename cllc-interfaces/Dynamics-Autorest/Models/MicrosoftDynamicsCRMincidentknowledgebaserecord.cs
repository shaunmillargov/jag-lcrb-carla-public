// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Gov.Lclb.Cllb.Interfaces.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class MicrosoftDynamicsCRMincidentknowledgebaserecord
    {
        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMincidentknowledgebaserecord class.
        /// </summary>
        public MicrosoftDynamicsCRMincidentknowledgebaserecord()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// MicrosoftDynamicsCRMincidentknowledgebaserecord class.
        /// </summary>
        public MicrosoftDynamicsCRMincidentknowledgebaserecord(string incidentid = default(string), string incidentknowledgebaserecordid = default(string), string knowledgebaserecordid = default(string), object versionnumber = default(object))
        {
            Incidentid = incidentid;
            Incidentknowledgebaserecordid = incidentknowledgebaserecordid;
            Knowledgebaserecordid = knowledgebaserecordid;
            Versionnumber = versionnumber;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "incidentid")]
        public string Incidentid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "incidentknowledgebaserecordid")]
        public string Incidentknowledgebaserecordid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "knowledgebaserecordid")]
        public string Knowledgebaserecordid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "versionnumber")]
        public object Versionnumber { get; set; }

    }
}
