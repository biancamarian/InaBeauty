using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InaBeauty.Models
{
    public class Membru
    {
        /*public int ID { get; set; }*/
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prima litera trebuie sa fie mare")]
        public string Nume { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prima litera trebuie sa fie mare")]
        public string Prenume { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Data Angajare")]
        public DateTime DataAngajare { get; set; }

        [Display(Name = "Nume Complet")]
        public string NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<AlocareServiciu> AlocariServicii { get; set; }

    }
}
