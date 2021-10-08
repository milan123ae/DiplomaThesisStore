using DatabaseAccess.Entiteti;
using System.Collections.Generic;
namespace DatabaseAccess.DTOs
{
    public class PredmetView
    {
        public int IdPredmeta { get; set; }
        public string NazivPredmeta { get; set; }

        public IList<SmerView> Smerovi { get; set; }
        public IList<UciNaView> Uci { get; set; }

        public IList<NastavnoOsobljeView> Nastavnici { get; set; }
        public IList<AngazovanNaView> Angazovan { get; set; }

        public IList<DiplomskiRadView> DiplomskiRadovi { get; set; }

        public IList<GodineView> Godine { get; set; }

        public PredmetView()
        {
            Godine = new List<GodineView>();
            Nastavnici = new List<NastavnoOsobljeView>();
            Angazovan = new List<AngazovanNaView>();
            Smerovi = new List<SmerView>();
            Uci = new List<UciNaView>();
            DiplomskiRadovi = new List<DiplomskiRadView>();

        }

        public PredmetView(Predmet p)
        {
            IdPredmeta = p.Id_Predmeta;
            NazivPredmeta = p.NazivPredmeta;

        }
    }

}