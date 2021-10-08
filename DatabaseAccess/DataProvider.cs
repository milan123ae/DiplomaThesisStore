using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using DatabaseAccess;
using NHibernate;
using DatabaseAccess.Entiteti;
using DatabaseAccess.DTOs;

namespace DatabaseAccess
{
    public class DataProvider
    {
        //STUDENT ////////////////////////////////////////////////////////
        #region Student
        public static void ObrisiStudenta(string Email)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                Student stud = s.Load<Student>(Email);

                s.Delete(stud);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static List<StudentView> VratiSveStudente()
        {
            List<StudentView> studenti = new List<StudentView>();

            try
            {
                ISession s = DataLayer.OpenSession;
                IEnumerable<Student> sviStudenti = from o in s.Query<Student>()
                                                   select o;
                foreach (Student p in sviStudenti)
                {
                    var smerovi = p.UpisaoSmer;
                    p.DatumUpisa.ToString("d");
                    var studentii = new StudentView(p)
                    {
                        UpisaoSmerr = new SmerView(p.UpisaoSmer)

                    };
                    studenti.Add(studentii);
                }
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return studenti;
        }

    public static List<StudentView> VratiStudenteSmer(int IdSmera)
        {
            List<StudentView> odInfos = new List<StudentView>();

            try
            {
                ISession s = DataLayer.OpenSession;

                IEnumerable<Student> studenti = from o in s.Query<Student>()
                                                where o.UpisaoSmer.IdSmera == IdSmera
                                                select o;

                foreach (Student o in studenti)
                {
                    var st = new StudentView(o)
                    {
                        UpisaoSmerr = new SmerView(o.UpisaoSmer)
                    };

                    odInfos.Add(st);
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return odInfos;
        }
        public static void DodajStudenta(StudentView stud)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                Student o = new Student();
                Smer p = s.Load<Smer>(stud.UpisaoSmerr.IdSmera);

                o.Email = stud.Email;
                o.Password = stud.Password;
                o.Jmbg = Int64.Parse(stud.Jmbg);
                o.Ime = stud.Ime;
                o.Prezime = stud.Prezime;
                o.BrojIndeksa = Int64.Parse(stud.BrojIndeksa);
                o.NivoStudija = stud.NivoStudija;
                o.Ulica = stud.Ulica;
                o.Broj = Int32.Parse(stud.Broj);
                o.DatumUpisa = DateTime.Parse(stud.DatumUpisa);
                o.UpisaoSmer = p;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch
            {
                throw;
            }
        }

        public static StudentView VratiStudenta(string Email)
        {
            StudentView studentView;
            try
            {
                ISession s = DataLayer.OpenSession;

                Student u = s.Load<Student>(Email);
                studentView = new StudentView(u);
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return studentView;
        }
        public static void UpdateStudent(StudentView stud)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                Student u = s.Load<Student>(stud.Email);
                //  Smer p = s.Load<Smer>(stud.UpisaoSmerr.IdSmera);

                u.Password = stud.Password;
                u.Jmbg = Int64.Parse(stud.Jmbg);
                u.Ime = stud.Ime;
                u.Prezime = stud.Prezime;
                u.NivoStudija = stud.NivoStudija;
                u.BrojIndeksa = Int64.Parse(stud.BrojIndeksa);
                u.Ulica = stud.Ulica;
                u.Broj = Int32.Parse(stud.Broj);
                u.DatumUpisa = DateTime.Parse(stud.DatumUpisa);
                //  u.UpisaoSmer = p;

                s.SaveOrUpdate(u);
                s.Flush();
                s.Close();
            }
            catch (Exception )
            {
                throw;
            }
        }

        #endregion
        //SMER ///////////////////////////////////////////////////
        #region Smer
        public static List<SmerView> VratiSveSmerove()
        {
            List<SmerView> smerovi = new List<SmerView>();

            try
            {
                ISession s = DataLayer.OpenSession;

                IEnumerable<Smer> sviSmerovi = from o in s.Query<Smer>()
                                               select o;

                foreach (Smer p in sviSmerovi)
                {
                    smerovi.Add(new SmerView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return smerovi;
        }

        public static void DodajSmer(SmerView p)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                Smer o = new Smer
                {
                    NazivSmera = p.NazivSmera,
                    BrojStudenta = Int32.Parse(p.BrojStudenta),
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static SmerView AzurirajSmer(SmerView p)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                Smer o = s.Load<Smer>(p.IdSmera);
                o.NazivSmera = p.NazivSmera;
                o.BrojStudenta = Int32.Parse(p.BrojStudenta);

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }

        public static SmerView VratiSmer(int id)
        {
            SmerView smerView;

            try
            {
                ISession s = DataLayer.OpenSession;

                Smer o = s.Load<Smer>(id);
                smerView = new SmerView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return smerView;
        }

        public static void ObrisiSmer(int id)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                Smer o = s.Load<Smer>(id);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion
        //PREDMET//////////////////////////////////////////
        #region Predmeti


        public static List<PredmetView> VratiSvePredmete()
        {
            List<PredmetView> predmeti = new List<PredmetView>();

            try
            {
                ISession s = DataLayer.OpenSession;

                IEnumerable<Predmet> sviPredmeti = from o in s.Query<Predmet>()
                                                   select o;

                foreach (Predmet p in sviPredmeti)
                {
                    // Predmeti bez smera
                    // predmeti.Add(new PredmetView(p));

                    // Sa smerovima na kojima se uce
                    var smerovi = p.Uci;
                    var predmet = new PredmetView(p)
                    {
                        Uci = smerovi.Select(p => new UciNaView(p)).ToList()
                    };
                    predmeti.Add(predmet);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return predmeti;
        }

        public static PredmetView AzurirajPredmet(PredmetView p)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                Predmet o = s.Load<Predmet>(p.IdPredmeta);

                o.NazivPredmeta = p.NazivPredmeta;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }

        public static PredmetView VratiPredmet(int id)
        {
            PredmetView predmetView;

            try
            {
                ISession s = DataLayer.OpenSession;

                Predmet p = s.Load<Predmet>(id);
                predmetView = new PredmetView(p);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return predmetView;
        }


        public static void ObrisiPredmet(int id)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                Predmet p = s.Load<Predmet>(id);
                // p.Uci.Clear();
                // p.Uci.Clear(); jedan predmet moze da se uci na vise smerova //ovo mozda nece biti potrebno

                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static List<PredmetView> VratiSvePredmeteeView()
        {
            List<PredmetView> ucina = new List<PredmetView>();

            try
            {
                ISession s = DataLayer.OpenSession;

                IEnumerable<Predmet> predmeti = from o in s.Query<Predmet>()
                                                select o;

                foreach (Predmet p in predmeti)
                {
                    PredmetView predmet = VratiPredmet(p.Id_Predmeta);
                    ucina.Add(predmet);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return ucina;
        }

        public static List<UciNaView> VratiPredmeteSmeraa(int smerId)
        {
            List<UciNaView> uci = new List<UciNaView>();

            try
            {
                ISession s = DataLayer.OpenSession;

                IEnumerable<UciNa> predmeti = from o in s.Query<UciNa>()
                                              where o.UceNa.IdSmera == smerId
                                              select o;

                foreach (UciNa p in predmeti)
                {
                    PredmetView predmet = VratiPredmet(p.Uci.Id_Predmeta);
                    SmerView smer = VratiSmer(p.UceNa.IdSmera);
                    uci.Add(new UciNaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return uci;
        }


        public static void SacuvajUciNa(UciNaView u)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                UciNa a = new UciNa
                {
                    Uci = s.Load<Predmet>(u.Uci.IdPredmeta),
                    UceNa = s.Load<Smer>(u.UceNa.IdSmera)
                };

                s.Save(a);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static int SacuvajPredmett(PredmetView p)
        {
            int id;
            try
            {
                ISession s = DataLayer.OpenSession;

                Predmet o = new Predmet
                {
                    NazivPredmeta = p.NazivPredmeta
                };

                id = (int)s.Save(o);
                // s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return id;
        }

        #endregion
        ///NASTAVNO_OSOBLJE
          #region NastavnoOsoblje


        public static List<NastavnoOsobljeView> VratiSveNastavnike()
        {
            List<NastavnoOsobljeView> nastavnici = new List<NastavnoOsobljeView>();

            try
            {
                ISession s = DataLayer.OpenSession;

                IEnumerable<NastavnoOsoblje> sviNastavnici = from o in s.Query<NastavnoOsoblje>()
                                                   select o;

                foreach (NastavnoOsoblje p in sviNastavnici)
                {
                    // Nastavnici bez predmeta
                    // nastavnici.Add(new NastavnoOsobljeView(p));

                    // Sa predmetima na kojima su angazovani
                    var predmeti = p.Angazovanje;
                    var nastavnik = new NastavnoOsobljeView(p)
                    {
                        Angazovanje = predmeti.Select(p => new AngazovanNaView(p)).ToList()
                    };
                    nastavnici.Add(nastavnik);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return nastavnici;
        }

        public static NastavnoOsobljeView AzurirajNastavnoOsoblje(NastavnoOsobljeView p)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                NastavnoOsoblje o = s.Load<NastavnoOsoblje>(p.Email);

                o.Password = p.Password;
                o.Jmbg = Int64.Parse(p.Jmbg);
                o.Lime = p.Lime;
                o.ImeRoditelja = p.ImeRoditelja;
                o.Prezime = p.Prezime;
                o.DatumRodjenja = DateTime.Parse(p.DatumRodjenja);
                o.Ulica = p.Ulica;
                o.Broj = int.Parse(p.Broj);

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }

        public static NastavnoOsobljeView VratiNastavnoOsoblje(string email)
        {
            NastavnoOsobljeView nastavnoOsobljeView;

            try
            {
                ISession s = DataLayer.OpenSession;

                NastavnoOsoblje p = s.Load<NastavnoOsoblje>(email);
                nastavnoOsobljeView = new NastavnoOsobljeView(p);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return nastavnoOsobljeView;
        }


        public static void ObrisiNastavnoOsoblje(string email)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                NastavnoOsoblje p = s.Load<NastavnoOsoblje>(email);
                // p.Angazovanje.Clear();
                // p.Angazovanje.Clear(); jedan nastavnik moze da predaje na vise predmeta //ovo mozda nece biti potrebno

                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }


        public static List<NastavnoOsobljeView> VratiSveNastavnikeView()
        {
            List<NastavnoOsobljeView> angazovanje = new List<NastavnoOsobljeView>();

            try
            {
                ISession s = DataLayer.OpenSession;

                IEnumerable<NastavnoOsoblje> nastavnici = from o in s.Query<NastavnoOsoblje>()
                                                select o;

                foreach (NastavnoOsoblje p in nastavnici)
                {
                    NastavnoOsobljeView nastavnik = VratiNastavnoOsoblje(p.Email);
                    angazovanje.Add(nastavnik);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return angazovanje;
        }

        public static List<AngazovanNaView> VratiNastavnikePredmeta(int predmetId)
        {
            List<AngazovanNaView> angazovanje = new List<AngazovanNaView>();

            try
            {
                ISession s = DataLayer.OpenSession;

                IEnumerable<AngazovanNa> nastavnici = from o in s.Query<AngazovanNa>()
                                              where o.Angazovan.Id_Predmeta == predmetId
                                              select o;

                foreach (AngazovanNa p in nastavnici)
                {
                    NastavnoOsobljeView nastavnik = VratiNastavnoOsoblje(p.Angazovanje.Email);
                    PredmetView predmet = VratiPredmet(p.Angazovan.Id_Predmeta);
                    angazovanje.Add(new AngazovanNaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return angazovanje;
        }


        public static void SacuvajAngazovanNa(AngazovanNaView u)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                AngazovanNa a = new AngazovanNa
                {
                    Angazovanje = s.Load<NastavnoOsoblje>(u.Angazovanje.Email),
                    Angazovan = s.Load<Predmet>(u.Angazovan.IdPredmeta)
                };

                s.Save(a);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static string SacuvajNastavnoOsoblje(NastavnoOsobljeView p)
        {
            string id;
            try
            {
                ISession s = DataLayer.OpenSession;

                NastavnoOsoblje o = new NastavnoOsoblje
                {
                    Email = p.Email,
                    Password = p.Password,
                    Jmbg = Int64.Parse(p.Jmbg),
                    Lime = p.Lime,
                    ImeRoditelja = p.ImeRoditelja,
                    Prezime = p.Prezime,
                    DatumRodjenja = DateTime.Parse(p.DatumRodjenja),
                    Ulica = p.Ulica,
                    Broj = int.Parse(p.Broj),
                    TipOsoblja = "NASTAVNO_OSOBLJE"

                };

                id = (string)s.Save(o);
                // s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
            return id;
        }

        #endregion

        //ADMINISTRACIJA ///////////////////////////////////////////////////
        #region Administracija
        public static List<AdministracijaView> VratiSveAdministracije()
        {
            List<AdministracijaView> admnistracije = new List<AdministracijaView>();

            try
            {
                ISession s = DataLayer.OpenSession;

                IEnumerable<Administracija> sveAdministracije = from o in s.Query<Administracija>()
                                               select o;

                foreach (Administracija p in sveAdministracije)
                {
                    admnistracije.Add(new AdministracijaView(p));
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return admnistracije;
        }

        public static void DodajAdministraciju(AdministracijaView p)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                Administracija o = new Administracija
                {
                    Email = p.Email,
                    Password = p.Password,
                    Jmbg = Int64.Parse(p.Jmbg),
                    Lime = p.Lime,
                    ImeRoditelja = p.ImeRoditelja,
                    Prezime = p.Prezime,
                    DatumRodjenja = DateTime.Parse(p.DatumRodjenja),
                    Ulica = p.Ulica,
                    Broj = Int32.Parse(p.Broj),
                    TipOsoblja = "ADMINISTRACIJA",
                    StrucnaSprema = p.StrucnaSprema
                };

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }

        public static AdministracijaView AzurirajAdministraciju(AdministracijaView p)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                Administracija o = s.Load<Administracija>(p.Email);
                o.Password = p.Password;
                o.Jmbg = Int64.Parse(p.Jmbg);
                o.Lime = p.Lime;
                o.ImeRoditelja = p.ImeRoditelja;
                o.Prezime = p.Prezime;
                o.DatumRodjenja = DateTime.Parse(p.DatumRodjenja);
                o.Ulica = p.Ulica;
                o.Broj = Int32.Parse(p.Broj);
                o.StrucnaSprema = p.StrucnaSprema;

                s.Update(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return p;
        }

        public static AdministracijaView VratiAdministraciju(string email)
        {
            AdministracijaView administracijaView;

            try
            {
                ISession s = DataLayer.OpenSession;

                Administracija o = s.Load<Administracija>(email);
                administracijaView = new AdministracijaView(o);

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw ;
            }

            return administracijaView;
        }

        public static void ObrisiAdministraciju(string email)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                Administracija o = s.Load<Administracija>(email);

                s.Delete(o);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion


        //DIPLOMSKI_RAD ////////////////////////////////////////////////////////
        #region DiplomskiRad
        public static void ObrisiDiplomskiRad(int id)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                DiplomskiRad diplomski = s.Load<DiplomskiRad>(id);

                s.Delete(diplomski);
                s.Flush();

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        public static List<DiplomskiRadView> VratiSveDiplomskeRadove()
        {
            List<DiplomskiRadView> diplRadovi = new List<DiplomskiRadView>();

            try
            {
                ISession s = DataLayer.OpenSession;
                IEnumerable<DiplomskiRad> sviDiplomskiRadovi = from o in s.Query<DiplomskiRad>()
                                                   select o;
                foreach (DiplomskiRad d in sviDiplomskiRadovi)
                {
                     var predmeti = d.UpisaoPredmet;
                    d.DatumOdbrane.ToString("d");
                    var diplomski = new DiplomskiRadView(d)
                    {
                           UpisaoPredmet = new PredmetView(d.UpisaoPredmet)

                        };
                  
                    diplRadovi.Add(diplomski);
                    //diplRadovi.Add(new DiplomskiRadView(d));
                }
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return diplRadovi;
        }

        public static List<DiplomskiRadView> VratiDiplomskiRadPredmet(int IdPredmeta)
        {
            List<DiplomskiRadView> odInfos = new List<DiplomskiRadView>();

            try
            {
                ISession s = DataLayer.OpenSession;

                IEnumerable<DiplomskiRad> diplRadovi = from o in s.Query<DiplomskiRad>()
                                                where o.UpisaoPredmet.Id_Predmeta == IdPredmeta
                                                select o;

                foreach (DiplomskiRad o in diplRadovi)
                {
                    var st = new DiplomskiRadView(o)
                    {
                        UpisaoPredmet = new PredmetView(o.UpisaoPredmet)
                    };

                    odInfos.Add(st);
                }

                s.Close();

            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return odInfos;
        }
        public static void DodajDiplomskiRad(DiplomskiRadView dipl)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                DiplomskiRad o = new DiplomskiRad();
                Predmet p = s.Load<Predmet>(dipl.UpisaoPredmet.IdPredmeta);
                Student z = s.Load<Student>(dipl.UpisaoStudent.Email);
                NastavnoOsoblje n = s.Load<NastavnoOsoblje>(dipl.Mentor.Email);
                o.Ocena = Int32.Parse(dipl.Ocena);
                o.NazivTeme = dipl.NazivTeme;
                o.DatumOdbrane = DateTime.Parse(dipl.DatumOdbrane);
                o.UpisaoStudent = z;
                o.Mentor = n;
                o.UpisaoPredmet = p;

                s.SaveOrUpdate(o);
                s.Flush();
                s.Close();
            }
            catch
            {
                throw;
            }
        }

        public static DiplomskiRadView VratiDiplomski(int id)
        {
            DiplomskiRadView diplomskiView;
            try
            {
                ISession s = DataLayer.OpenSession;

                DiplomskiRad u = s.Load<DiplomskiRad>(id);
                diplomskiView = new DiplomskiRadView(u);
                s.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return diplomskiView;
        }
        public static void UpdateDiplomskiRad(DiplomskiRadView dipl)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                DiplomskiRad u = s.Load<DiplomskiRad>(dipl.Id_Diplomski);
                //  Predmet p = s.Load<Predmet>(dipl.UpisaoPredmet.IdPredmeta);

                u.Ocena = Int32.Parse(dipl.Ocena);
                u.NazivTeme = dipl.NazivTeme;
                u.DatumOdbrane = DateTime.Parse(dipl.DatumOdbrane);
               // u.Mentor.Email = dipl.EmailNass;
                //u.UpisaoStudent.Email = dipl.EmailStudd;
                //  u.UpisaoPremet = p;

                s.SaveOrUpdate(u);
                s.Flush();
                s.Close();
            }
            catch (Exception )
            {
                throw;
            }
        }

        #endregion

        /////UciNa///////////////////////////////////////////////////////////////
        #region UciNa

        public static List<UciNaView> VratiSveUciNa()
        {
            List<UciNaView> predmeti = new List<UciNaView>();

            try
            {
                ISession s = DataLayer.OpenSession;

                IEnumerable<UciNa> sviPredmeti = from o in s.Query<UciNa>()
                                                   select o;

                foreach (UciNa p in sviPredmeti)
                {
                    // Predmeti bez smera
                    // predmeti.Add(new PredmetView(p));

                    // Sa smerovima na kojima se uce
                    var smerovi = p.Uci;
                    var predmet = new UciNaView(p)
                    {
                        //Uci = smerovi.Select(p => new UciNaView(p)).ToList()
                    };
                    predmeti.Add(predmet);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return predmeti;
        }

        public static void ObrisiUciNa(int id)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                UciNa p = s.Load<UciNa>(id);

                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion

        /////AngazovanNa///////////////////////////////////////////////////////////////
        #region AngazovanNa

        public static List<AngazovanNaView> VratiSveAngazovanNa()
        {
            List<AngazovanNaView> angazovani = new List<AngazovanNaView>();

            try
            {
                ISession s = DataLayer.OpenSession;

                IEnumerable<AngazovanNa> sviAngazovani = from o in s.Query<AngazovanNa>()
                                                 select o;

                foreach (AngazovanNa p in sviAngazovani)
                {

                    var predmeti = p.Angazovanje;
                    var nastavnik = new AngazovanNaView(p)
                    {
                        //Uci = smerovi.Select(p => new UciNaView(p)).ToList()
                    };
                    angazovani.Add(nastavnik);
                }

                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }

            return angazovani;
        }

        public static void ObrisiAngazovanNa(int id)
        {
            try
            {
                ISession s = DataLayer.OpenSession;

                AngazovanNa p = s.Load<AngazovanNa>(id);

                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception)
            {
                //handle exceptions
                throw;
            }
        }
        #endregion
    }
}
