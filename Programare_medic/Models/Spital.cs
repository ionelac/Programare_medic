using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Programare_medic.Models
{
    public class Spital
    {
        public int ID { get; set; }

        [Display(Name = "Denumire spital")]
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Denumirea spitalului trebuie să înceapă cu majusculă și să aibă o lungime minimă de caractere 3. Ai văzut tu spital de 3 litere? C'mon")]
        [StringLength(30, MinimumLength = 3)]
        public string DenumireSpital { get; set; }
        public ICollection<Serviciu>? Servicii { get; set; } //navigation property
    }
}
