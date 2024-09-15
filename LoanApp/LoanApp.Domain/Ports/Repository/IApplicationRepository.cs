using LoanApp.Domain.Dto;

namespace LoanApp.Domain.Ports.Repository
{
    public interface IApplicationRepository
    {
        public Task<ResponseDto> Create(ApplicationDto application);
        public Task<int> GetLastId();
    }
}
