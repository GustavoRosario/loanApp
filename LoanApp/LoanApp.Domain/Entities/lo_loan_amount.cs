using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace LoanApp.Domain.Entities
{
    public class lo_loan_amount
    {
        [Key]
        public int loan_amount_id { get; set; }
        public string loan_amount { get; set; }
        public bool active { get; set; }
    }
}
