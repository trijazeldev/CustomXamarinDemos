using System.Collections.Generic;
using Newtonsoft.Json;

namespace AdaptiveCardsDemo.Portable.Models.Cards
{
    public partial class Column
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("width")]
        public string Width { get; set; }

        [JsonProperty("items")]
        public List<ColumnItem> Items { get; set; }
    }
}
