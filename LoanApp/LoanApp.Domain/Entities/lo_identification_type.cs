using System.ComponentModel.DataAnnotations;

namespace LoanApp.Domain.Entities
{
    public class lo_identification_type
    {
        [Key]
        public int identification_type_id { get; set; }
        public Guid ref_id { get; set; }
        public string identification_type { get; set; }
        public bool active { get; set; }

    }
}
