using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MyCarbonFootprintCalculator;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;

namespace MyCarbonFootprintCalculator.Models
{
    public class GenInfoMod
    {
        public GenInfoMod()
        {
            if (ZipCode is null)
            {
                City = "city";
                State = "state";
                ZipCode = "00000";
            }
        }

        [Key]
        public int UserId { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [Required]
        [JsonPropertyName("postal_code")]
        public string ZipCode { get; set; }
        [AllowNull]
        public int AnnualIncome { get; set; }

        public static async Task<GenInfoMod> Lookup(string zip)
        {
            GenInfoMod place = new GenInfoMod();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            string requestUrl = $"http://zip.getziptastic.com/v2/us/{zip}";

            response = await client.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                place.ZipCode = zip;
                place = JsonSerializer.Deserialize<GenInfoMod>(result.ToString());
            }
            return place;
        }
    }
}
