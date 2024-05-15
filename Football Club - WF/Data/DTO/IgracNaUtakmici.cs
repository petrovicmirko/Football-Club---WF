using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Club___WF.Data.DTO
{
    internal class IgracNaUtakmici
    {
        public Osoba IDOsobe { get; set; }
        public int IDUtakmice { get; set; }
        public bool UProtokolu { get; set; }
        public int MinutaUIgri { get; set; }
        public int Golovi { get; set; }
        public int Asistencije { get; set; }
        public int ZutiKarton { get; set; }
        public int CrveniKarton { get; set; }
    }
}
