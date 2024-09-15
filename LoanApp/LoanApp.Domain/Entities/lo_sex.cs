using System.ComponentModel.DataAnnotations;

namespace LoanApp.Domain.Entities
{
    public class lo_sex
    {
        [Key]
        public int sex_id { get; set; }
        public Guid ref_id { get; set; }
        public string sex { get; set; }
        public bool active { get; set; }

    }
}
