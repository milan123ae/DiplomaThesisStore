using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;
namespace DatabaseAccess.Mapiranje
{
    public class DiplomskiRadMapiranje : ClassMap<DatabaseAccess.Entiteti.DiplomskiRad>
    {
       public DiplomskiRadMapiranje()
        {
            Table("DIPLOMSKI_RAD");
            Id(x => x.Id_Diplomski, "ID_DIPLOMSKI").GeneratedBy.Identity();

            Map(x => x.Ocena).Column("OCENA");
            Map(x => x.NazivTeme).Column("NAZIV_TEME");
            Map(x => x.DatumOdbrane).Column("DATUM_ODBRANE");
            References(x => x.UpisaoStudent).Column("EMAIL_STUD").LazyLoad();
            References(x => x.UpisaoPredmet).Column("ID_PREDMETA").LazyLoad();
            References(x => x.Mentor).Column("EMAIL_NAS").LazyLoad();

        }
    }
}
