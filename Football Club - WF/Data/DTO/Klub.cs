using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Club___WF.Data.DTO
{
    internal class Klub
    {
        public int IDKluba { get; set; } 
        public string NazivKluba { get; set; }
        public DateTime DatumOsnivanja { get; set; }
        public string Grad { get; set; }   

    }
}
