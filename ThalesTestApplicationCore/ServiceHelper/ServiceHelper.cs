using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ThalesTestApplicationCore.ServiceHelper
{
    public static class ServiceHelper
    {
        public static async Task<string> GetIRequest(string serviceUri)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(serviceUri);
                  
            }
        }
    }
}
