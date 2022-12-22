using System;
using System.Text.Json.Serialization;

namespace BloodeAPI.Models
{
    public class DistrictList
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("citiesList")]
        public List<string>? CitiesList { get; set; }
    }

    public class IndianStates
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("districtList")]
        public List<DistrictList>? DistrictList { get; set; }
    }

    public class StatesList
    {
        public List<IndianStates>? States { get; set; }
    }

}

