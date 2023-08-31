using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace B3.DesafioCalculo.Shared.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJsonIgnoringNullValues(this object valor)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.SerializeObject(valor, settings);
        }
    }
}
