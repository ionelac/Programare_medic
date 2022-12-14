using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Programare_medic.Models
{
    public class Programare
    {
        public int ID { get; set; }
        public int? PacientID { get; set; }
        public Pacient? Pacient { get; set; }

        public int? MedicID { get; set; }
        public Medic? Medic { get; set; }

        public int? ServiciuID { get; set; }
        public Serviciu? Serviciu{ get; set; }

        [DataType(DataType.Date)]
        public DateTime DataProgramare { get; set; }

        public int? SpitalID { get; set; }
        public Spital? Spital { get; set; }
    }
}
