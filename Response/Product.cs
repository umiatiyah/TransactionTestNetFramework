using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TransactionTestWithNetFramework.Response
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ProductResponse
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}