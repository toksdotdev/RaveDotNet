using Newtonsoft.Json;

namespace RaveDotNet.Services.JSONConverter
{
    public static class Serialize
    {
        public static string ToJson<T>(this T self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }
}