using Newtonsoft.Json;

namespace aspnetzabota.Content.Datamodel.Doctors
{
    public class Doctor
    {
        [JsonProperty("descr")]
        public string Description { get; set; }

        [JsonProperty("fio")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("schedule")]
        public Schedule Schedule { get; set; }

        [JsonProperty("sex")]
        public string Sex { get; set; }
    }
}
