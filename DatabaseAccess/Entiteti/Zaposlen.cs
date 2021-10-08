using System;
using System.Collections.Generic;


namespace DatabaseAccess.Entiteti
{
    public class Zaposlen
    {
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual Int64 Jmbg { get; set; }
        public virtual string Lime { get; set; }
        public virtual string ImeRoditelja { get; set; }
        public virtual string Prezime { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string Ulica { get; set; }
        public virtual int Broj { get; set; }
        public virtual string TipOsoblja { get; set; }
        public virtual IList<TelefonZ> TelefoniZ { get; set; }
        
        public Zaposlen()
        {
            TelefoniZ = new List<TelefonZ>();
        }
    }
    public class NastavnoOsoblje : Zaposlen
    {
        public virtual IList<Predmet> Predmetii { get; set; }
        public virtual IList<AngazovanNa> Angazovanje { get; set; }
        public virtual IList<DiplomskiRad> DiplomskiRadovi { get; set; }
        public NastavnoOsoblje()
        {
            Predmetii = new List<Predmet>();
            Angazovanje = new List<AngazovanNa>();
            DiplomskiRadovi = new List<DiplomskiRad>();
        }
    }
    public class Administracija : Zaposlen
    {
        public virtual string StrucnaSprema { get; set; }

    }
}
