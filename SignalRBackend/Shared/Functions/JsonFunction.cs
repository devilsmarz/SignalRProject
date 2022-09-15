using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace SignalRBackend.WEB.Shared.Functions
{
    public static class JsonFunction
    {
        public static String SerializeObject<T>(T obj)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
        }
    }
}
