using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using SignalRBackend.BLL.DTO;
using SignalRBackend.DAL.DomainModels;
using SignalRBackend.WEB.ViewModels;
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
