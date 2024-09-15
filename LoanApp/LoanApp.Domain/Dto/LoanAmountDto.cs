using System;

namespace LoanApp.Domain.Dto
{
    public class LoanAmountDto
    {
        public int loan_amount_id { get; set; }
        public string doctor_type { get; set; }
        public decimal loan_amount { get; set; }
        public bool active { get; set; }
    }
}
