using System.Collections.Generic;
using aspnetzabota.Content.Database.Entities;
using aspnetzabota.Content.Datamodel.Doctors;

namespace aspnetzabota.Web.ViewModels
{
    public class DoctorInfoSettingsViewModel
    {
        public IEnumerable<DoctorSchedule> Doctor { get; set; }
        public DoctorSchedule SingleDoctor { get; set; }

}
}
