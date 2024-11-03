using System.Text.Json.Serialization;

namespace PersonApp.Core.Entities.Api
{
    public class Name
    {
        [JsonPropertyName("first")]
        public string First { get; set; }

        [JsonPropertyName("last")]
        public string Last { get; set; }
    }
}
