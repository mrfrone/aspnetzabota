using aspnetzabota.Common.Result;
using aspnetzabota.Common.Result.ErrorCodes;
using aspnetzabota.Content.Database.Entities;
using aspnetzabota.Content.Database.Repository.DoctorInfo;
using aspnetzabota.Content.Datamodel.Doctors;
using aspnetzabota.Content.Services.Upload;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace aspnetzabota.Content.Services.Schedule
{
    internal class Schedule : ISchedule
    {
        private readonly Random random = new Random();
        private readonly IDoctorInfoRepository _doctorInfoRepository;
        private readonly IMapper _mapper;
        private readonly IUpload _upload;
        public Schedule(IDoctorInfoRepository doctorInfoRepository, IMapper mapper, IUpload upload)
        {
            _doctorInfoRepository = doctorInfoRepository;
            _mapper = mapper;
            _upload = upload;
        }
        private IEnumerable<DoctorSchedule> RemoveNoReception(IEnumerable<DoctorSchedule> model)
        {
            string symb = "-";
            string phrase = "нет приема";
            foreach (var mod in model)
            {
                if (mod.doctors.schedule.mon == phrase)
                    mod.doctors.schedule.mon = symb;
                if (mod.doctors.schedule.tue == phrase)
                    mod.doctors.schedule.tue = symb;
                if (mod.doctors.schedule.wed == phrase)
                    mod.doctors.schedule.wed = symb;
                if (mod.doctors.schedule.thu == phrase)
                    mod.doctors.schedule.thu = symb;
                if (mod.doctors.schedule.fri == phrase)
                    mod.doctors.schedule.fri = symb;
                if (mod.doctors.schedule.sat == phrase)
                    mod.doctors.schedule.sat = symb;
                if (mod.doctors.schedule.sun == phrase)
                    mod.doctors.schedule.sun = symb;
            }
            return model;
        }
        private async Task<IEnumerable<DoctorSchedule>> JsonSchedule()
        {
                using (StreamReader sr = new StreamReader("wwwroot/json/schedule.json"))
                {
                    return RemoveNoReception(JsonConvert
                        .DeserializeObject<IEnumerable<DoctorSchedule>>(await sr.ReadToEndAsync()))
                        .OrderBy(c => c.category);
                }
        }
        private async Task<IEnumerable<DoctorSchedule>> ScheduleAtDoctors(bool OnlyComplete = false)
        {
            var doctors = await GetDoctorsInfo();
            var schedule = await JsonSchedule();
            foreach (var doctor in doctors)
            {
                if (!String.IsNullOrEmpty(schedule.FirstOrDefault(c => c.doctors.id == doctor.DoctorId).doctors.fio))
                    schedule.FirstOrDefault(c => c.doctors.id == doctor.DoctorId).DoctorInfo = doctor;
            }
            if (OnlyComplete)
            {
                return schedule.Where(x => x.DoctorInfo != null);
            }
            else
            {
                return schedule;
            }
        }
        public async Task<IEnumerable<DoctorSchedule>> Get(bool OnlyComplete = false)
        {
            return await ScheduleAtDoctors(OnlyComplete);
        }

        public async Task<IEnumerable<string>> Posts()
        {
            var schedule = await Get();
            return schedule.Select(c => c.category).Distinct().ToList();
        }

        public async Task<DoctorSchedule> Single(int id)
        {
            var schedule = await Get();
            return schedule.FirstOrDefault(c => c.doctors.id == id);
        }

        public async Task<IEnumerable<DoctorSchedule>> ScheduleFromSinglePost(int cat_id)
        {
            var schedule = await Get();
            return schedule.Where(c => c.cat_id == cat_id.ToString());
        }

        public async Task<IEnumerable<DoctorSchedule>> Random(int Count)
        {
            var schedule = await Get();
            return schedule.OrderBy(x => random.Next()).Take(Count);
        }

        public async Task<IEnumerable<DoctorSchedule>> GetPagedList(int pageNumber, int pageSize)
        {
            var schedule = await ScheduleAtDoctors();
            return await schedule.ToPagedListAsync(pageNumber, pageSize);
        }
        public async Task<IEnumerable<ZabotaDoctorInfo>> GetDoctorsInfo() 
        {
            var result = await _doctorInfoRepository.Get();
            return _mapper.Map<IEnumerable<ZabotaDoctorInfo>>(result);
        }
        public async Task<ZabotaResult> AddDoctorInfo(ZabotaDoctorInfo model)
        {
            var schedule = await JsonSchedule();
            if (!String.IsNullOrEmpty(schedule.FirstOrDefault(c => c.doctors.id == model.DoctorId).doctors.fio))
            {
                await _doctorInfoRepository.Add(model);
                return new ZabotaResult();
            }
            else
            {
                return ZabotaErrorCodes.IdNotFound;
            }
        }
        public async Task<ZabotaResult> UpdateDoctorInfo(ZabotaDoctorInfo model)
        {
                await _doctorInfoRepository.Update(model);

                return new ZabotaResult();
        }
        public async Task<ZabotaResult> DeleteDoctorInfo(int id)
        {
            var result = await _doctorInfoRepository.GetSingle(id);
            _upload.DeleteImage(result.Photo);

            await _doctorInfoRepository.Delete(id);

            return new ZabotaResult();
        }
    }
}
