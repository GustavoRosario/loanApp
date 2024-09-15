using System.ComponentModel.DataAnnotations;

namespace LoanApp.Domain.Entities
{
    public class lo_doctor_type
    {
        [Key]
        public int doctor_type_id { get; set; }
        public string doctor_type { get; set; }
        public bool active { get; set; }
    }
}
