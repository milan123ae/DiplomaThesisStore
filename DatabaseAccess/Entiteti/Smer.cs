using System;
using System.Collections.Generic;


namespace DatabaseAccess.Entiteti
{
    public class Smer
    {
        public virtual int IdSmera { get; set; }
        public virtual string NazivSmera { get; set; }
        public virtual int BrojStudenta { get; set; }
        public virtual IList<Student> Studenti1 { get; set; }
        public virtual IList<Predmet> Predmeti { get; set; }
        public virtual IList<UciNa> UceNa { get; set; }

        public Smer()
        {
            Studenti1 = new List<Student>();
            Predmeti = new List<Predmet>();
            UceNa = new List<UciNa>();
        }
    }
}
