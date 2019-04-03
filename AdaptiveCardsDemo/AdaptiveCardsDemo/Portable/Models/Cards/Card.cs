using System.Collections.Generic;
using Newtonsoft.Json;

namespace AdaptiveCardsDemo.Portable.Models.Cards
{
    public partial class Card
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("body")]
        public List<CardBody> Body { get; set; }

        [JsonProperty("actions")]
        public List<CardAction> Actions { get; set; }
    }
}
