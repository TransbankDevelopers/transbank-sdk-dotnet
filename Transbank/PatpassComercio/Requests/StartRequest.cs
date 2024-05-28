using Newtonsoft.Json;
using Transbank.Common;
using System.Net.Http;

namespace Transbank.PatpassComercio.Requests
{
    internal class StartRequest : BaseRequest
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("nombre")]
        public string Name { get; set; }
        
        [JsonProperty("pApellido")]
        public string FLastname { get; set; }
        
        [JsonProperty("sApellido")]
        public string SLastname { get; set; }
        
        [JsonProperty("rut")]
        public string Rut { get; set; }
        
        [JsonProperty("serviceId")]
        public string ServiceId { get; set; }
        
        [JsonProperty("finalUrl")]
        public string FinalUrl { get; set; }
        
        [JsonProperty("commerceCode")]
        public string CommerceCode { get; set; }
        
        [JsonProperty("montoMaximo")]
        public string MaxAmount { get; set; }
        
        [JsonProperty("telefonoFijo")]
        public string PhoneNumber { get; set; }
        
        [JsonProperty("telefonoCelular")]
        public string MobileNumber { get; set; }
        
        [JsonProperty("nombrePatPass")]
        public string PatpassName { get; set; }
        
        [JsonProperty("correoPersona")]
        public string PersonEmail { get; set; }
        
        [JsonProperty("correoComercio")]
        public string CommerceEmail { get; set; }
        
        [JsonProperty("direccion")]
        public string Address { get; set; }
        
        [JsonProperty("ciudad")]
        public string City { get; set; }

        internal StartRequest(
            string url, 
            string name, 
            string fLastname, 
            string sLastname, 
            string rut, 
            string serviceId, 
            string finalUrl, 
            string commerceCode, 
            string maxAmount, 
            string phoneNumber, 
            string mobileNumber, 
            string patpassName, 
            string personEmail, 
            string commerceEmail, 
            string address, 
            string city
            ) : base($"{ApiConstants.PATPASS_COMERCIO_ENDPOINT}/patInscription", HttpMethod.Post)
        {
            Url = url;
            Name = name;
            FLastname = fLastname;
            SLastname = sLastname;
            Rut = rut;
            ServiceId = serviceId;
            FinalUrl = finalUrl;
            CommerceCode = commerceCode;
            MaxAmount = maxAmount;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            PatpassName = patpassName;
            PersonEmail = personEmail;
            CommerceEmail = commerceEmail;
            Address = address;
            City = city;
        }
    }
}
