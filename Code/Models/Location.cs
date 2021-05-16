using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyCarbonFootprintCalculator.Models
{
    public class Location
    {
        public Location()
        {
            if (Zip is null)
            {
                City = "city";
                State = "state";
                Zip = "00000";
            }
        }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("postal_code")]
        public string Zip { get; set; }
        public static async Task<Location> Lookup(string zip)
        {
            Location place = new Location();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            string requestUrl = $"http://zip.getziptastic.com/v2/us/{zip}";

            response = await client.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                place.Zip = zip;
                place = JsonSerializer.Deserialize<Location>(result.ToString());
            }
            return place;
        }
    }
}
