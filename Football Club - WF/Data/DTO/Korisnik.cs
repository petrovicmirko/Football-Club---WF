using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Club___WF.Data.DTO
{
    internal class Korisnik
    {
        public Osoba IDOsobe { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public bool Uloga { get; set; }
        public int Tema { get; set; } 
    }
}
