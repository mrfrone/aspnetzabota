namespace aspnetzabota.Content.Database.Entities
{
    public class DoctorInfo
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public int DoctorId { get; set; }
    }
}
