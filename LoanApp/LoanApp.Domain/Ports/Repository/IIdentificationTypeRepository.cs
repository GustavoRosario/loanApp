using LoanApp.Domain.Dto;

namespace LoanApp.Domain.Ports.Repository
{
    public interface IIdentificationTypeRepository
    {
        public Task<List<IdentificationTypeDto>> GetData();
    }
}
