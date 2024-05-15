using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Club___WF.Data.DTO
{
    internal class Utakmica
    {
        public int IDUtakmice;
        public DateTime DatumVrijeme;
        public bool Domacin;
        public int BrojDatihGolova;
        public int BrojPrimljenihGolova;
        public string FazaKolo;
        public bool StatusUtakmice;
        public int IDProtivnickogKluba;
        public int IDTakmicenja;
        public int IDSezone;
    }
}
