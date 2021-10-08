using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.Mapiranje
{
    public class GodineMapiranje : ClassMap<DatabaseAccess.Entiteti.Godine>
    {
        public GodineMapiranje()
        {
            Table("GODINE");
            Id(x => x.IdGodine, "ID_GODINE").GeneratedBy.Identity();
            Map(x => x.Godina).Column("GODINA");
            References(x => x.Predmeti1).Column("ID_PREDMETA").LazyLoad();
        }
    }
}
