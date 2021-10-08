using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.Mapiranje
{
    public class TelefonZMapiranje : ClassMap<DatabaseAccess.Entiteti.TelefonZ>
    {
        public TelefonZMapiranje()
        {
            Table("TELEFON_Z");
            Id(x => x.IdTelefona, "ID_TELEFONA").GeneratedBy.Identity();
            Map(x => x.Telefon).Column("TELEFON");
            References(x => x.Zaposlenfon).Column("EMAIL").LazyLoad();
        }
    }
}
