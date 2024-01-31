using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEntityLib
{
    public class Oblast
    {
        public int ID { get; set; }
        public string? NazivOblasti { get; set; }
        public int PredmetID { get; set; }
        [ForeignKey("PredmetID")]
        public Predmet? Predmet { get; set; }

        public ICollection<Zadatak> Zadatak { get; set; } = new List<Zadatak>();
    }
}
