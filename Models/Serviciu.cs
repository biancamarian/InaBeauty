using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InaBeauty.Models
{
    public class Serviciu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        /*public int ServiciuID { get; set; }*/
        public int ServiciuID { get; set; }
        [StringLength(50, MinimumLength =3)]
        public string Denumire { get; set; }
        public string Descriere { get; set; }
        public int Durata { get; set; }
        [Range(0, 5)]
        public int Pret { get; set; }
        public ICollection<Programare> Programari { get; set; }
        public ICollection<AlocareServiciu> AlocariServicii { get; set; }
    }
}