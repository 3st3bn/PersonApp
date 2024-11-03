using System.Text.Json.Serialization;

namespace PersonApp.Core.Entities.Api
{
    public class Result
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("cell")]
        public string Cell { get; set; }

        [JsonPropertyName("picture")]
        public Picture Picture { get; set; }

    }
}
