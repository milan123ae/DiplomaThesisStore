using DatabaseAccess.Entiteti;
using System.Collections.Generic;
using System;

namespace DatabaseAccess.DTOs
{
    public class SmerView
    {
        public int IdSmera { get; set; }
        public string NazivSmera { get; set; }
        public string BrojStudenta { get; set; }
        public IList<StudentView> Studenti1 { get; set; }
        public IList<PredmetView> Predmeti { get; set; }
        public IList<UciNaView> UceNa { get; set; }

        public SmerView()
        {
            Studenti1 = new List<StudentView>();
            Predmeti = new List<PredmetView>();
            UceNa = new List<UciNaView>();
        }

        public SmerView(Smer s)
        {
            IdSmera = s.IdSmera;
            NazivSmera = s.NazivSmera;
            BrojStudenta = s.BrojStudenta.ToString();
        }
    }
}
