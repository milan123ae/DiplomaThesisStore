using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;


namespace DatabaseAccess.Mapiranje
{
    public class PredmetMapiranje : ClassMap<DatabaseAccess.Entiteti.Predmet>
    {
        public PredmetMapiranje()
        {
            Table("PREDMET");
            Id(x => x.Id_Predmeta, "ID_PREDMETA").GeneratedBy.Identity();
            Map(x => x.NazivPredmeta).Column("NAZIV_PREDMETA");

            HasMany(x => x.Godine).KeyColumn("ID_PREDMETA").Cascade.All().Inverse();

            HasManyToMany(x => x.Smerovi)
            .Table("UCI_NA")
            .ParentKeyColumn("ID_PREDMETA")
            .ChildKeyColumn("ID_SMERA");
            //.Cascade.All();
            //.Inverse();
            // HasMany(x => x.Uci).KeyColumn("ID_PREDMETA").LazyLoad().Inverse();//.Cascade.All().Inverse();

            HasManyToMany(x => x.Nastavnici)
              .Table("ANGAZOVAN_NA")
              .ParentKeyColumn("ID_PREDMETA")
              .ChildKeyColumn("EMAIL_NASTAVNIKA");
            // .Cascade.All()
            //  .Inverse();
            // HasMany(x => x.Angazovan).KeyColumn("ID_PREDMETA").LazyLoad();//Cascade.All().Inverse();

            HasMany(x => x.DiplomskiRadovi).KeyColumn("ID_PREDMETA").Cascade.All().Inverse();


        }
    }
}
