using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InaBeauty.Models.SalonViewModels
{
    public class ProgramareDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DataProgramare { get; set; }
        public int ClientiNr { get; set; }
    }
}
