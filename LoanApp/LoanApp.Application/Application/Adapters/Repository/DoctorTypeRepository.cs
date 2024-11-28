using LoanApp.Application.Helpers;
using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity.Data;

namespace LoanApp.Application.Application.Adapters.Repository
{
    public class DoctorTypeRepository : IDoctorTypeRepository
    {
        private LoanAppDbContext LoanDbContext { get; set; }

        public DoctorTypeRepository(LoanAppDbContext LoanDbContext)
        {
            this.LoanDbContext = LoanDbContext;
        }
        public async Task<List<DoctorTypeDto>> GetData()
        {
            List<DoctorTypeDto> lst = null;
            var lstProvince = LoanDbContext.lo_doctor_type.Where(x => x.doctor_type_id > 0 && x.active == true).ToList();

            lst = lstProvince.ConvertAll(x =>
            {
                return new DoctorTypeDto()
                {
                    DoctorTypeId = x.doctor_type_id,
                    DoctorType = x.doctor_type
                };
            });

            return await Task.Run(() => lst);
        }

        public async Task<DoctorTypeDto> GetData(int doctorTypeId)
        {
            DoctorTypeDto doctorTypeDto = null;
            var doctorType = LoanDbContext.lo_doctor_type.Where(x => x.doctor_type_id == doctorTypeId && x.active == true).First();

            doctorTypeDto = new DoctorTypeDto()
            {
                DoctorTypeId = doctorType.doctor_type_id,
                DoctorType = doctorType.doctor_type
            };

            return await Task.Run(() => doctorTypeDto);
        }
    }
}
