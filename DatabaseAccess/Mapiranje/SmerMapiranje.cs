using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;


namespace DatabaseAccess.Mapiranje
{
    public class SmerMapiranje : ClassMap<DatabaseAccess.Entiteti.Smer>
    {
        public SmerMapiranje()
        {
            Table("SMER");
            Id(x => x.IdSmera, "ID_SMERA").GeneratedBy.Identity();
            Map(x => x.NazivSmera).Column("NAZIV_SMERA");
            Map(x => x.BrojStudenta).Column("BROJ_STUDENTA");

            HasMany(x => x.Studenti1).KeyColumn("ID_SMERA").LazyLoad().Cascade.All().Inverse();

            HasManyToMany(x => x.Predmeti)
             .Table("UCI_NA")
             .ParentKeyColumn("ID_SMERA")
             .ChildKeyColumn("ID_PREDMETA");
             // .Cascade.All();
             // .Inverse();
            //HasMany(x => x.UceNa).KeyColumn("ID_SMERA").LazyLoad().Cascade.All().Inverse();
        }
    }
}
