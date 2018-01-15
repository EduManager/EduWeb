using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Edu.Infrastructure.Helper
{
    public class JsonHelper
    {
        static JsonSerializerSettings SerializationSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Converters = new List<JsonConverter> { new IsoDateTimeConverter() {DateTimeFormat ="yyyy-MM-dd HH:mm:ss" } }
        };

        /// <summary>
        /// 将对象转为json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None, SerializationSettings);
            }
            catch (System.Exception e)
            {
                LogHelper.Error(typeof(JsonHelper),"Json序列化失败!", e);
                throw;
            }
        }
        /// <summary>
        /// 将字符串转为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string json) where T : class
        {
            try
            {
                var t = JsonConvert.DeserializeObject(json, typeof(T), SerializationSettings);
                return t as T;
            }
            catch (System.Exception e)
            {
                LogHelper.Error(typeof(JsonHelper), "Json反序列化失败!", e);
                throw;
            }
        }
        
    }
}
