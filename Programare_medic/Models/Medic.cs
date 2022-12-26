using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Programare_medic.Models
{
    public class Medic
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Numele trebuie să înceapă cu majusculă (ex: Pop) și să fie minim de 3 litere")]
        [StringLength(30, MinimumLength = 3)]
        public string Nume { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Prenumele trebuie să înceapă cu majusculă (ex: Mihai) și să fie minim de 3 litere. Dacă te cheamă Le, Jo, ... ghinion :)")]
        [StringLength(30, MinimumLength = 3)]
        public string Prenume { get; set; }

        [Display(Name = "Nume complet")]
        public string NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Serviciu>? Servicii { get; set; }
    }
}
