using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp.Domain.Dto
{
    public class ApplicationEmailDto
    {
        public string ApplicationId { get; set; }
        public string Doctortype { get; set; }
        public string Medicalcenter { get; set; }
        public string Passingtime { get; set; }
        public string Specialty { get; set; }
        public string Yearofresidence { get; set; }
        public int Statusid { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Province { get; set; }
        public int Identificationtypeid { get; set; }
        public string Identification { get; set; }
        public byte Identificationimage { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public int Personprovinceid { get; set; }
        public string Movil { get; set; }
        public string Directfamilyname { get; set; }
        public string Typefamilyrelationship { get; set; }
        public string Directfamilytelephone { get; set; }
        public decimal Amounttolend { get; set; }
    }
}
