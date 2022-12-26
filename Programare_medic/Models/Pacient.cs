using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Programare_medic.Models
{
    public class Pacient
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Numele trebuie să înceapă cu majusculă (ex: Pop) și să fie minim de 3 litere")]
        [StringLength(30, MinimumLength = 3)]
        public string? Nume { get; set; }


        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Prenumele trebuie să înceapă cu majusculă (ex: Mihai) și să fie minim de 3 litere. Dacă te cheamă Le, Jo, ... ghinion :)")]
        [StringLength(30, MinimumLength = 3)]
        public string? Prenume { get; set; }
        public int? Varsta { get; set; }

        [RegularExpression("^\\S+@\\S+\\.\\S+$")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Emailul nu poate începe cu caractere speciale și nici nu se poate termina astfel! (Ex valid: anapop@gmail.com)")]
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Formatul numărului de telefon trebuie să fie de genul '0744-666-100' sau'0744.666.100' sau '0744 666 100'")]
        public string? Telefon { get; set; }
        [Display(Name = "Nume complet")]
        public string? NumeComplet
        {
            get
            {
                return Prenume + " " + Nume;
            }
        }
        public ICollection<Programare>? Programari { get; set; }
    }
}
