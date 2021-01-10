using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InaBeauty.Models
{
    public class Programare
    {
        [Key]
        public int ProgramareID { get; set; }
        public int ServiciuID { get; set; }
        public int ClientID { get; set; }

        public Serviciu Serviciu { get; set; }
        public Client Client { get; set; }
    }
}
