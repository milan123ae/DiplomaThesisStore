using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.Mapiranje
{
    public class ZaposlenMapiranje : ClassMap<DatabaseAccess.Entiteti.Zaposlen>
    {
        public ZaposlenMapiranje()
        {
            Table("ZAPOSLEN");
            DiscriminateSubClassesOnColumn("TIP_OSOBLJA");

            Id(x => x.Email).GeneratedBy.Assigned().Column("EMAIL");

            Map(x => x.Password).Column("PASSWORD");
            Map(x => x.Jmbg).Column("JMBG");
            Map(x => x.Lime).Column("L_IME");
            Map(x => x.ImeRoditelja).Column("IME_RODITELJA");
            Map(x => x.Prezime).Column("PREZIME");
            Map(x => x.DatumRodjenja).Column("DATUM_RODJENJA");
            Map(x => x.Ulica).Column("ULICA");
            Map(x => x.Broj).Column("BROJ");

            HasMany(x => x.TelefoniZ).KeyColumn("EMAIL").Cascade.All().Inverse();
        }
    }
    public class NastavnoOsobljeMapiranje : SubclassMap<DatabaseAccess.Entiteti.NastavnoOsoblje>
    {
        public NastavnoOsobljeMapiranje()
        {
            DiscriminatorValue("NASTAVNO_OSOBLJE");
            //Table("NASTAVNO_OSOBLJE");

            HasManyToMany(x => x.Predmetii)
                .Table("ANGAZOVAN_NA")
                .ParentKeyColumn("EMAIL_NASTAVNIKA")
                .ChildKeyColumn("ID_PREDMETA");
            // .Cascade.All();
            // .Inverse()      
            // HasMany(x => x.Angazovanje).KeyColumn("JMBG_NASTAVNIKA").LazyLoad();//.Cascade.All().Inverse();
            HasMany(x => x.DiplomskiRadovi).KeyColumn("EMAIL_NAS").LazyLoad().Cascade.All().Inverse();

        }

    }
    public class AdministracijaMapiranje : SubclassMap<DatabaseAccess.Entiteti.Administracija>
    {
        public AdministracijaMapiranje()
        {
            DiscriminatorValue("ADMINISTRACIJA");
            //Table("ADMINISTRACIJA");
            Map(x => x.StrucnaSprema).Column("STRUCNA_SPREMA");


        }

    }
}
