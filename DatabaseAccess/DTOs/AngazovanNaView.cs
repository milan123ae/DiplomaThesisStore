using DatabaseAccess.Entiteti;
using System;

namespace DatabaseAccess.DTOs
{
    public class AngazovanNaView
    {
        public int Id { get; set; }
        public NastavnoOsobljeView Angazovanje { get; set; }
        public PredmetView Angazovan { get; set; }
        public DateTime DatumAngazovanja { get; set; }

        public AngazovanNaView()
        {
        }

        public AngazovanNaView(AngazovanNa a)
        {
            Id = a.Id;
            Angazovanje = new NastavnoOsobljeView(a.Angazovanje);
            Angazovan = new PredmetView(a.Angazovan);
            DatumAngazovanja = a.DatumAngazovanja;
        }
    }
}
