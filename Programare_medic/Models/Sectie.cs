namespace Programare_medic.Models
{
    public class Sectie
    {
        public int ID { get; set; }

        public string DenumireSectie { get; set; }
        public ICollection<ServiciuSectie>? ServiciuSectii { get; set; }
    }
}
