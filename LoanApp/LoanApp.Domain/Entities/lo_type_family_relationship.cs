using System.ComponentModel.DataAnnotations;

namespace LoanApp.Domain.Entities
{
    public class lo_type_family_relationship
    {
        [Key]
        public int type_family_relationship_id { get; set; }
        public Guid ref_id { get; set; }
        public string type_family_relationship { get; set; }
        public bool active { get; set; }
    }
}
