using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp.Domain.Dto
{
    public class WhatsAppDto
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Boby { get; set; }
        public ApplicationDto Application { get; set; }
    }
}
