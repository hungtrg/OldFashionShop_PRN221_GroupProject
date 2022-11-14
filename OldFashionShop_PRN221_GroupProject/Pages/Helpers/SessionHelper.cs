using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace OldFashionShop_PRN221_GroupProject.Helpers
{
    public static class SessionHelper
    {

        public static void SetObjectAsJson(this ISession session, string key, object obj)
        {
            session.SetString(key, JsonConvert.SerializeObject(obj));
        }

        public static T? GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}