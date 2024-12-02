using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity.Data;

namespace LoanApp.Application.Application.Adapters.Repository
{
    public class LoanAmountRepository : ILoanAmountRepository
    {
        private LoanAppDbContext LoanDbContext { get; set; }

        public LoanAmountRepository(LoanAppDbContext loanDbContext)
        {
            this.LoanDbContext = loanDbContext;
        }
        public async Task<List<LoanAmountDto>> GetData()
        {
            var lstLoanAmount = LoanDbContext.lo_loan_amount.Where(x => x.active == true).ToList();

            var lst = lstLoanAmount.ConvertAll(x =>
            {
                return new LoanAmountDto()
                {
                    loan_amount_id = x.loan_amount_id,
                    loan_amount = x.loan_amount
                };
            });

            return await Task.Run(() => lst);
        }
    }
}
