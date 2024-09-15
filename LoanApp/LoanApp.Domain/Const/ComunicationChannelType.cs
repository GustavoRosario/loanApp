using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp.Domain.Const
{
    public class ComunicationChannelType
    {
        public static int IssuingTelephone { get => 3; }
        public static int ReceiverTelephone { get => 1; }
        public static int IssuingEmail { get => 6; }
        public static int ReceiverEmail { get => 2; }
        public static int TokenEmail { get => 7; }
    }
}
