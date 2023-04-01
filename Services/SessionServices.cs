using Newtonsoft.Json;
using Assignment.Models;

namespace Shopping_Application.Services
{
    public static class SessionServices
    {
        public static List<Clothes> GetObjFromSession(ISession session, string key)
        {
            var jsondata = session.GetString(key);
            if (jsondata == null) return new List<Clothes>();
            var clotheses = JsonConvert.DeserializeObject<List<Clothes>>(jsondata);
            return clotheses;
        }
        public static void SetObjToSession(ISession session, string key,object value)
        {
            var jsondata = JsonConvert.SerializeObject(value);
            session.SetString(key, jsondata);
        }
        public static bool CheckObjInList(Guid id, List<Clothes> products)
        {
            return products.Any(x => x.ID == id);   
        }
    }
}
