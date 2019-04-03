using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AdaptiveCardsDemo.Portable.Models.Cards
{
    public partial class AdaptiveCard
    {
        [JsonProperty("$schema")]
        public Uri Schema { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("body")]
        public List<AdaptiveCardBody> Body { get; set; }

        [JsonProperty("actions")]
        public List<AdaptiveCardAction> Actions { get; set; }
    }
}
