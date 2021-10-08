using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Mapiranje;

namespace DatabaseAccess
{
    public class DataLayer
    {
        private static volatile ISessionFactory iSessionFactory;
        private static object syncRoot = new Object();

        public static ISession OpenSession
        {
            get
            {
                if (iSessionFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (iSessionFactory == null)
                        {
                            iSessionFactory = BuildSessionFactory();
                        }
                    }
                }
                return iSessionFactory.OpenSession();
            }
        }

        private static ISessionFactory BuildSessionFactory()
        {
            try
            {
               // string connectionString = System.Configuration.ConfigurationManager.AppSettings["Initial Catalog = DiplomskiRad; Data Source =.; User ID = milan; Password = milan0123456789; Integrated Security = False; "];
               // SqlConnection conn = new SqlConnection();
                  string connectionString =
                  "Data Source=.;" +
                  "Initial Catalog=DiplomskiRad;" +
                  "Integrated Security=SSPI;";
               // conn.Open();
                return Fluently.Configure()
                     .Database(MsSqlConfiguration.MsSql2012
                     .ConnectionString(connectionString))
                     .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StudentMapiranje>())
                    // .ExposeConfiguration(BuildSchema)
                     .BuildSessionFactory();
            }
            catch (Exception ex)
            {
               // System.Windows.Forms.MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        /* Create session */
      /*  private static AutoPersistenceModel CreateMappings()
        {
            return AutoMap
                .Assembly(System.Reflection.Assembly.GetCallingAssembly())
                .Where(t => t.Namespace == "DatabaseAccess.Entiteti");
        }

        private static void BuildSchema(Configuration config)
        {
        } */

    }
}
