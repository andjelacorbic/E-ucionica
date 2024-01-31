using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEntityLib
{
    public class Predmet
    {
        public int ID { get; set; }
        public string? Naziv { get; set; }
        public string? Profesor { get; set; }
        public int? Razred { get; set; }
        public ICollection<Zadatak> Zadatak { get; set; } = new List<Zadatak>();
        public ICollection<Oblast> Oblast { get; set; } = new List<Oblast>();

    }
}
