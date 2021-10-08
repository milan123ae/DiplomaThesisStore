using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.Mapiranje
{
    public class StudentMapiranje : ClassMap<DatabaseAccess.Entiteti.Student>
    {
         public StudentMapiranje()
        {
            Table("STUDENT");
            Id(x => x.Email).GeneratedBy.Assigned().Column("EMAIL");

            Map(x => x.Password).Column("PASSWORD");
            Map(x => x.Jmbg).Column("JMBG");
            Map(x => x.Ime).Column("IME");
            Map(x => x.Prezime).Column("PREZIME");
            Map(x => x.NivoStudija).Column("NIVO_STUDIJA");
            Map(x => x.BrojIndeksa).Column("BR_INDEKSA");
            Map(x => x.Ulica).Column("ULICA");
            Map(x => x.Broj).Column("BROJ");
            Map(x => x.DatumUpisa).Column("DATUM_UPISA");

            HasMany(x => x.DiplRadovi).KeyColumn("EMAIL_STUD").LazyLoad().Cascade.All().Inverse();
            References(x => x.UpisaoSmer).Column("ID_SMERA").LazyLoad();
            HasMany(x => x.TelefoniS).KeyColumn("EMAIL").Cascade.All().Inverse();




        }
    }
}
