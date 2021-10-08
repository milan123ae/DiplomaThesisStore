using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranje
{
    public class UciNaMapiranje : ClassMap<DatabaseAccess.Entiteti.UciNa>
    {
        public UciNaMapiranje()
       {
           Table("UCI_NA");
           Id(x => x.UciNaId, "ID_UCI_NA").GeneratedBy.Identity();
           References(x => x.UceNa).Column("ID_SMERA").LazyLoad();
           References(x => x.Uci).Column("ID_PREDMETA").LazyLoad();


       }
    }
}
