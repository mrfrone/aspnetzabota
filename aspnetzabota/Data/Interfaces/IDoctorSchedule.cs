using aspnetzabota.Data.Models;
using System.Collections.Generic;

namespace aspnetzabota.Data.Interfaces
{
    public interface IDoctorSchedule
    {
        IEnumerable<DoctorScheduleModel> Take { get; }
    }
}
