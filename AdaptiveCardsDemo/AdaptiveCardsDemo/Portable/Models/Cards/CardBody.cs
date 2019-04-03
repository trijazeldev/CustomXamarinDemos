using Newtonsoft.Json;

namespace AdaptiveCardsDemo.Portable.Models.Cards
{
    public partial class CardBody
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isMultiline")]
        public bool IsMultiline { get; set; }

        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }
    }
}
