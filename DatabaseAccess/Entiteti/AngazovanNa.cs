using System;


namespace DatabaseAccess.Entiteti
{
    public class AngazovanNa
    {
        public virtual int Id { get; set; }
        public virtual NastavnoOsoblje Angazovanje { get; set; }
        public virtual Predmet Angazovan { get; set; }
        public virtual DateTime DatumAngazovanja { get; set; }

        public AngazovanNa()
        {
        }
    }
}
