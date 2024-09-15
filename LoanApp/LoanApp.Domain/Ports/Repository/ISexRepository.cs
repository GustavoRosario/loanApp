using LoanApp.Domain.Dto;

namespace LoanApp.Domain.Ports.Repository
{
    public interface ISexRepository
    {
        public Task<List<SexDto>> GetData();
        public Task<SexDto> GetData(int sexId);
    }
}
