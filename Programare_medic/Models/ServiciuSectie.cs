namespace Programare_medic.Models
{
    public class ServiciuSectie
    {
        public int ID { get; set; }
        public int ServiciuID { get; set; }
        public Serviciu Serviciu { get; set; }
        public int SectieID { get; set; }
        public Sectie Sectie  { get; set; }

    }
}
