using System.Security.Policy;
using Programare_medic.Models;

namespace Programare_medic.Models.ViewModels
{
    public class SpitalIndexData
    {
        public IEnumerable<Spital> Spitale { get; set; }
        public IEnumerable<Serviciu> Servicii { get; set; }
    }
}
