using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Programare_medic.Models
{
    public class Serviciu
    {
        public int ID { get; set; }

        [Display(Name = "Serviciu")]
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Denumirea serviciului trebuie să înceapă cu majusculă și să aibă o lungime minimă de caractere 3")]
        [StringLength(70, MinimumLength = 3)]
        public string Denumire_Serviciu { get; set; }

        public int? MedicID { get; set; }
        public Medic? Medic { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 14000)]
        [Display(Name = "Cost consultație")]
        public decimal Cost_consultatie { get; set; }

        [Display(Name = "Data Programare")]
        [DataType(DataType.Date)]
        public DateTime Data_Programare { get; set; }

        public int? SpitalID { get; set; }
        public Spital? Spital { get; set; }

        [Display(Name = "Serviciu Secții")]
        public ICollection<ServiciuSectie>? ServiciuSectii { get; set; }
    }
}
