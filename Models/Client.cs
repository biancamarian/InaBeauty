using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InaBeauty.Models
{
    public class Client
    {
        public int ID { get; set; }
        [Required]
       [StringLength(20, MinimumLength =3, ErrorMessage = "Numele este prea scurt/lung")]
       [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prima litera trebuie sa fie mare")]
        public string Nume { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prima litera trebuie sa fie mare")]
        [StringLength(20, MinimumLength =3, ErrorMessage ="Numele este prea scurt/lung")]
        public string Prenume { get; set; }
       [DataType(DataType.Date)]
       [Display(Name = "Data Programare")]
        public DateTime DataProgramare { get; set; }
        [Display(Name ="Nume Complet")]
        public string NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }

        public ICollection<Programare> Programari { get; set; }
    }
}
