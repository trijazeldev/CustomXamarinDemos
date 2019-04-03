using System.Collections.Generic;
using Newtonsoft.Json;

namespace AdaptiveCardsDemo.Portable.Models.Cards
{
    public partial class BodyItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
        public string Weight { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public string Size { get; set; }

        [JsonProperty("columns", NullValueHandling = NullValueHandling.Ignore)]
        public List<Column> Columns { get; set; }

        [JsonProperty("wrap", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Wrap { get; set; }

        [JsonProperty("facts", NullValueHandling = NullValueHandling.Ignore)]
        public List<Fact> Facts { get; set; }
    }
}
