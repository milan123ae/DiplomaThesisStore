using System;
using System.Collections.Generic;


namespace DatabaseAccess.Entiteti
{
    public class Student
    {
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual Int64 Jmbg { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string NivoStudija { get; set; }
        public virtual Int64 BrojIndeksa { get; set; }
        public virtual string Ulica { get; set; }
        public virtual int Broj { get; set; }
        public virtual DateTime DatumUpisa { get; set; }
        public virtual IList<DiplomskiRad> DiplRadovi { get; set; }
        public virtual IList<TelefonS> TelefoniS { get; set; }
        public virtual Smer UpisaoSmer { get; set; }

        public Student()
        {
            DiplRadovi = new List<DiplomskiRad>();
            TelefoniS = new List<TelefonS>();


        }
    }
}
