namespace Programare_medic.Models
{
    public class ServiciuData
    {
        //Corespondenta serviciu - sectie
        public IEnumerable<Serviciu> Servicii { get; set; }
        public IEnumerable<Sectie> Sectii { get; set; }
        public IEnumerable<ServiciuSectie> ServiciuSectii { get; set; }
    }
}
