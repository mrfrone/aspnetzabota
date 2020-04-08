using aspnetzabota.Content.Database.Entities;
using Newtonsoft.Json;

namespace aspnetzabota.Content.Datamodel.Doctors
{
    public class DoctorSchedule
    {
        [JsonProperty("cat_id")]
        public string CategoryID { get; set; }

        [JsonProperty("category")]
        public string CategoryName { get; set; }

        [JsonProperty("depart_id")]
        public int DepartmentID { get; set; }

        [JsonProperty("depart_name")]
        public string DepartmentName { get; set; }

        [JsonProperty("doctors")]
        public Doctor Doctor { get; set; }

        public ZabotaDoctorInfo DoctorInfo { get; set; }
    }
}
