using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity.Data;
using LoanApp.Application.Helpers;
using LoanApp.Domain.Entities;

namespace LoanApp.Application.Application.Adapters.Repository
{
    public class LoanAmount : ILoanAmount
    {
        private LoanAppDbContext LoanDbContext { get; set; }

        public LoanAmount(LoanAppDbContext loanDbContext)
        {
            this.LoanDbContext = loanDbContext;
        }
        public async Task<List<LoanAmountDto>> GetData()
        {
            List<LoanAmountDto> lst = null;
            var lstLoanAmount = LoanDbContext.lo_loan_amount.Where(x => x.loan_amount_id > 0 && x.active == true).ToList();

            lst = lstLoanAmount.ConvertAll(x =>
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
