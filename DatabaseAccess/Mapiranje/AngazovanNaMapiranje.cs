using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.Mapiranje
{
    public class AngazovanNaMapiranje : ClassMap<DatabaseAccess.Entiteti.AngazovanNa>
    {
       public AngazovanNaMapiranje()
        {
            Table("ANGAZOVAN_NA");

            Id(x => x.Id, "ID_ANGAZOVAN").GeneratedBy.Identity();

            References(x => x.Angazovan, "ID_PREDMETA"); 

            References(x => x.Angazovanje, "EMAIL_NASTAVNIKA");


            Map(x => x.DatumAngazovanja).Column("DATUM_ANGAZOVANJA");
        }

    }
}
