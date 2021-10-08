using DatabaseAccess.Entiteti;
using System.Collections.Generic;

namespace DatabaseAccess.DTOs
{
    public class NastavnoOsobljeView : ZaposlenView
    {

        public IList<PredmetView> Predmetii { get; set; }
        public IList<AngazovanNaView> Angazovanje { get; set; }
        public IList<DiplomskiRadView> DiplomskiRadovi { get; set; }
        public NastavnoOsobljeView()
        {
            Predmetii = new List<PredmetView>();
            Angazovanje = new List<AngazovanNaView>();
            DiplomskiRadovi = new List<DiplomskiRadView>();
        }

        public NastavnoOsobljeView(Zaposlen z) : base(z)
        {
 
        }
    }
}
