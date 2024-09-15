using System.ComponentModel.DataAnnotations;

namespace LoanApp.Domain.Entities
{
    public class lo_year_of_residence
    {
        [Key]
        public int year_of_residence_id { get; set; }
        public string year_of_residence { get; set; }
        public bool active { get; set; }
    }
}
