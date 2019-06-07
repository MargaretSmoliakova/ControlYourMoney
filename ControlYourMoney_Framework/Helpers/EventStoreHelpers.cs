using System.Text;
using Newtonsoft.Json;

namespace ControlYourMoney_Framework.Helpers
{
    public static class EventStoreHelpers
    {
        public static byte[] Serialize(this object target)
        {
            return Encoding.UTF8.GetBytes(
                JsonConvert.SerializeObject(
                    target,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Objects
                    }));
        }
    }
}

