using System.ComponentModel.DataAnnotations;

namespace LoanApp.Domain.Entities
{
    public class lo_province
    {
        [Key]
        public int province_id { get; set; }
        public Guid ref_id { get; set; }
        public string province { get; set; }
        public bool active { get; set; }
    }
}
