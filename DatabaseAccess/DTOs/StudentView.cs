using DatabaseAccess.Entiteti;
using System.Collections.Generic;
using System;

namespace DatabaseAccess.DTOs
{
    public class StudentView
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string NivoStudija { get; set; }
        public string BrojIndeksa { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string DatumUpisa { get; set; }
       // public int IdSmera { get; set; }
        public IList<DiplomskiRadView> DiplRadovi { get; set; }
        public IList<TelefonSView> TelefoniS { get; set; }

        public SmerView UpisaoSmerr { get; set; }

        public StudentView()
        {
            DiplRadovi = new List<DiplomskiRadView>();
            TelefoniS = new List<TelefonSView>();
        }

        public StudentView(Student s)
        {
            Email = s.Email;
            Password = s.Password;
            Jmbg = s.Jmbg.ToString();
            Ime = s.Ime;
            Prezime = s.Prezime;
            NivoStudija = s.NivoStudija;
            BrojIndeksa = s.BrojIndeksa.ToString();
            Ulica = s.Ulica;
            Broj = s.Broj.ToString();
            DatumUpisa = s.DatumUpisa.ToShortDateString();
          //  IdSmera = s.UpisaoSmer.IdSmera;
        }
    }
}
