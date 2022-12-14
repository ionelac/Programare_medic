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

        public string Denumire_Serviciu { get; set; }
        public string Medic { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Cost_consultatie { get; set; }
        [Display(Name = "Data Programare")]
        [DataType(DataType.Date)]
        public DateTime Data_Programare { get; set; }

        public int? SpitalID { get; set; }
        public Spital? Spital { get; set; }
        public ICollection<ServiciuSectie>? ServiciuSectii { get; set; }


    }
}
