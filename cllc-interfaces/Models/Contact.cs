// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Gov.Lclb.Cllb.Interfaces.Spice.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Contact
    {
        /// <summary>
        /// Initializes a new instance of the Contact class.
        /// </summary>
        public Contact()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Contact class.
        /// </summary>
        /// <param name="selfDisclosure">Possible values include: 'Yes',
        /// 'No'</param>
        /// <param name="gender">Possible values include: 'Male', 'Female',
        /// 'Other'</param>
        public Contact(string contactId = default(string), string firstName = default(string), string lastName = default(string), string middleName = default(string), string companyName = default(string), string phoneNumber = default(string), string email = default(string), GeneralYesNo? selfDisclosure = default(GeneralYesNo?), AdoxioGenderCode? gender = default(AdoxioGenderCode?), string driversLicenceNumber = default(string), string bcIdCardNumber = default(string), Address address = default(Address))
        {
            ContactId = contactId;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            CompanyName = companyName;
            PhoneNumber = phoneNumber;
            Email = email;
            SelfDisclosure = selfDisclosure;
            Gender = gender;
            DriversLicenceNumber = driversLicenceNumber;
            BcIdCardNumber = bcIdCardNumber;
            Address = address;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "contactId")]
        public string ContactId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "middleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Yes', 'No'
        /// </summary>
        [JsonProperty(PropertyName = "selfDisclosure")]
        public GeneralYesNo? SelfDisclosure { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Male', 'Female', 'Other'
        /// </summary>
        [JsonProperty(PropertyName = "gender")]
        public AdoxioGenderCode? Gender { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "driversLicenceNumber")]
        public string DriversLicenceNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bcIdCardNumber")]
        public string BcIdCardNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

    }
}
