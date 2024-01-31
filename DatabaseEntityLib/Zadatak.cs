using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEntityLib
{
    public class Zadatak
    {
        public int ID { get; set; }
        
        public int PredmetID { get; set; }
        [ForeignKey("PredmetID")]
        public Predmet? Predmet { get; set; }
        public int OblastID { get; set; }
        [ForeignKey("OblastID")]
        public Oblast? Oblast { get; set; }
        public int TezinaID { get; set; }
        [ForeignKey("TezinaID")]
        public NivoTezine? NivoTezine { get; set; }
        public string? Pitanje { get; set; }
        
        public string? Image { get; set; }
    }
}
