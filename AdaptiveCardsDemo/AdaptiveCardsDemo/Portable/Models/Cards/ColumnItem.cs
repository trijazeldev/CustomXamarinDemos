using System;
using Newtonsoft.Json;

namespace AdaptiveCardsDemo.Portable.Models.Cards
{
    public partial class ColumnItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public string Size { get; set; }

        [JsonProperty("style", NullValueHandling = NullValueHandling.Ignore)]
        public string Style { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
        public string Weight { get; set; }

        [JsonProperty("wrap", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Wrap { get; set; }

        [JsonProperty("spacing", NullValueHandling = NullValueHandling.Ignore)]
        public string Spacing { get; set; }

        [JsonProperty("isSubtle", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsSubtle { get; set; }
    }
}
