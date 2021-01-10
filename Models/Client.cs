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
       [StringLength(20, ErrorMessage = "Numele nu poate sa fie mai lung de 50 de caractere.")]
       [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prima litera trebuie sa fie mare")]
        public string Nume { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prima litera trebuie sa fie mare")]
        [StringLength(20, ErrorMessage ="Numele este prea lung")]
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
