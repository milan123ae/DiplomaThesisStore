using DatabaseAccess.Entiteti;
using System;

namespace DatabaseAccess.DTOs
{
    public class DiplomskiRadView 
    {
        public  int Id_Diplomski { get; set; }
        public string Ocena { get; set; }
        public string NazivTeme { get; set; }
        public string DatumOdbrane { get; set; }
        public string EmailStudd { get; set; }
        public string EmailNass { get; set; }
        public string IdPredmetaa { get; set; }

        public string EmailStud;
        public string EmailNas;
        public string IdPredmeta;

        public StudentView UpisaoStudent { get; set; }
        public PredmetView UpisaoPredmet { get; set; }

        public NastavnoOsobljeView Mentor { get; set; }

        public DiplomskiRadView()
        {
        }

        public DiplomskiRadView(DiplomskiRad d)
        {
            Id_Diplomski = d.Id_Diplomski;
            Ocena = d.Ocena.ToString();
            NazivTeme = d.NazivTeme;
            DatumOdbrane = d.DatumOdbrane.ToShortDateString();
            EmailStudd = d.UpisaoStudent.Email;
            EmailNass = d.Mentor.Email;
            IdPredmetaa = d.UpisaoPredmet.Id_Predmeta.ToString();
        }
    }
}
