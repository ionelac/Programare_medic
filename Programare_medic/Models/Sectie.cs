using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Programare_medic.Models
{
    public class Sectie
    {
        public int ID { get; set; }

        [Display(Name = "Denumire secție")]
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Denumirea secției trebuie să înceapă cu majusculă și să aibă o lungime minimă de caractere 3. Ai văzut tu secție de 3 litere? C'mon")]
        [StringLength(30, MinimumLength = 3)]
        public string DenumireSectie { get; set; }
        public ICollection<ServiciuSectie>? ServiciuSectii { get; set; }
    }
}
