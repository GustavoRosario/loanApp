using System.ComponentModel.DataAnnotations;

namespace LoanApp.Domain.Entities
{
    public class lo_communication_channel
    {
        [Key]
        public int communication_channel_id { get; set; }
        public string communication_channel_value { get; set; }
        public int communication_channel_type_id { get; set; }
        public bool active { get; set; }
    }
}
