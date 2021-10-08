using System;


namespace DatabaseAccess.Entiteti
{
    public class DiplomskiRad
    {
        public virtual int Id_Diplomski { get; set; }
        public virtual int Ocena { get; set; }
        public virtual string NazivTeme { get; set; }
        public virtual DateTime DatumOdbrane { get; set; }

        public virtual Student UpisaoStudent { get; set; }
        public virtual Predmet UpisaoPredmet { get; set; }
        
        public virtual NastavnoOsoblje Mentor { get; set; }

        public DiplomskiRad()
        {
        }

    }
}
