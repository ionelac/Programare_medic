namespace Programare_medic.Models
{
    public class Spital
    {
        public int ID { get; set; }
        public string DenumireSpital { get; set; }
        public ICollection<Serviciu>? Servicii { get; set; } //navigation property
    }
}
