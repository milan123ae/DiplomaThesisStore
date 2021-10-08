using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.Mapiranje
{
    public class TelefonSMapiranje : ClassMap<DatabaseAccess.Entiteti.TelefonS>
    {
        public TelefonSMapiranje()
        {
            Table("TELEFON_S");
            Id(x => x.IdTelefona, "ID_TELEFONA").GeneratedBy.Identity();
            Map(x => x.Telefon).Column("TELEFON");
            References(x => x.Studentfon).Column("EMAIL").LazyLoad();
        }
    }
}
