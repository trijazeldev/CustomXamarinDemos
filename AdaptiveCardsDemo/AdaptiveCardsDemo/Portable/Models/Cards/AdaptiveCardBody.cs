using System.Collections.Generic;
using Newtonsoft.Json;

namespace AdaptiveCardsDemo.Portable.Models.Cards
{
    public partial class AdaptiveCardBody
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("items")]
        public List<BodyItem> Items { get; set; }
    }
}
