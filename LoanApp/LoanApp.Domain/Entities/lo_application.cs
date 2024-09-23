using System.ComponentModel.DataAnnotations;

namespace LoanApp.Domain.Entities
{
    public class lo_application
    {
        [Key]
        public int application_id { get; set; }
        public Guid ref_id { get; set; }
        public int doctor_type_id { get; set; }
        public string medical_center { get; set; }
        public string passing_time { get; set; }
        public string specialty { get; set; }
        public int year_of_residence_id { get; set; }
        public int status_id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public int province_id { get; set; }
        public int identification_type_id { get; set; }
        public string identification { get; set; }
        public byte identification_image { get; set; }
        public int sex_id { get; set; }
        public string address { get; set; }
        public int person_province_id { get; set; }
        public string movil { get; set; }
        public string direct_family_name { get; set; }
        public int type_family_relationship_id { get; set; }
        public string direct_family_telephone { get; set; }
        public string amount_to_lend { get; set; }
        public DateTime record_date { get; set; }
        public DateTime record_time { get; set; }
        public bool active { get; set; }

    }
}
