using DatabaseAccess.Entiteti;
namespace DatabaseAccess.DTOs
{
    public class GodineView
    {
        public  int IdGodine { get; set; }
        public int Godina { get; set; }
        public PredmetView Predmeti1 { get; set; }
        public int IdPredmeta;

        public GodineView()
        {

        }

        public GodineView(Godine g)
        {
            IdGodine = g.IdGodine;
            Godina = g.Godina;
            IdPredmeta = g.Predmeti1.Id_Predmeta;

        }
    }

}