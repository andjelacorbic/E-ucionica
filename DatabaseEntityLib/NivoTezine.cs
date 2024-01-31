using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEntityLib
{
    public class NivoTezine
    {
        public int ID { get; set; }
        public string? Tezina { get; set; }

        public ICollection<Zadatak> Zadatak { get; set; } = new List<Zadatak>();
    }
}
