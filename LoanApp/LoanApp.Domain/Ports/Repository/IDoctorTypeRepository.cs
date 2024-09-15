using LoanApp.Domain.Dto;

namespace LoanApp.Domain.Ports.Repository
{
    public interface IDoctorTypeRepository
    {
        public Task<List<DoctorTypeDto>> GetData();
        public Task<DoctorTypeDto> GetData(int doctorTypeId);
    }
}
