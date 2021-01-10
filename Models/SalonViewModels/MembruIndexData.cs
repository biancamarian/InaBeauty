using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaBeauty.Models.SalonViewModels
{
    public class MembruIndexData
    {
        public IEnumerable<Membru> Membrii { get; set; }

        public IEnumerable<Serviciu> Servicii { get; set; }

        public IEnumerable<Programare> Programari { get; set; }
    }
}
