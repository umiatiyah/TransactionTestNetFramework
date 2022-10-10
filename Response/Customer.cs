using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TransactionTestWithNetFramework.Response
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class CustomerResponse
    {
        public int ID { get; set;  }
        public string NIK { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public string NoTelp { get; set; }
        public string Address { get; set; }
        public string NoRekening { get; set; }
    }
}