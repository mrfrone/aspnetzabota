using Newtonsoft.Json;

namespace aspnetzabota.Content.Datamodel.Doctors
{
    public class Schedule
    {
        [JsonProperty("mon")]
        public string Monday { get; set; }

        [JsonProperty("tue")]
        public string Tuesday { get; set; }

        [JsonProperty("wed")]
        public string Wednesday { get; set; }

        [JsonProperty("thu")]
        public string Thursday { get; set; }

        [JsonProperty("fri")]
        public string Friday { get; set; }

        [JsonProperty("sat")]
        public string Saturday { get; set; }

        [JsonProperty("sun")]
        public string Sunday { get; set; }
    }
}
