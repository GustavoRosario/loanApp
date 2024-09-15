using LoanApp.Domain.Dto;

namespace LoanApp.Domain.Ports.Repository
{
    public interface IYearOfResidenceRepository
    {
        public Task<List<YearOfResidenceDto>> GetData();
        public Task<YearOfResidenceDto> GetData(int yeraOdResidenceId);
    }
}
