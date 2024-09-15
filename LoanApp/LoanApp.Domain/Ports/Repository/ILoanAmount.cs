using LoanApp.Domain.Dto;

namespace LoanApp.Domain.Ports.Repository
{
    public interface ILoanAmount
    {
        public Task<List<LoanAmountDto>> GetData();
    }
}

