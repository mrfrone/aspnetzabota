﻿namespace aspnetzabota.Content.Datamodel.Doctors
{
    public class DoctorScheduleModel
    {
        public string cat_id { get; set; }
        public string category { get; set; }
        public int depart_id { get; set; }
        public string depart_name { get; set; }
        public doctors doctors { get; set; }
    }
}