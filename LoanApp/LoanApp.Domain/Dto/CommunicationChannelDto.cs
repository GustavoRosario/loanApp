using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp.Domain.Dto
{
    public class CommunicationChannelDto
    {
        public int communication_channel_type_id { get; set; }
        public string communication_channel_name_value { get; set; }
    }
}
