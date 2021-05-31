using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Projekat2Deo_Verzija1.Mapiranja;

namespace Projekat2Deo_Verzija1
{
    class DataLayer
    {
        private static ISessionFactory _factory = null;
        private static object objLock = new object();

        public static ISession GetSession()
        {
            if(_factory == null)
            {
                lock (objLock)
                {
                    if (_factory == null)
                        _factory = CreateSessionFactory();
                }
            }

            return _factory.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            try 
            { 
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                                                              .ConnectionString(c =>
                                                              c.Is("DATA SOURCE=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;PERSIST SECURITY INFO=True;USER ID=S17101;Password=projekat2020"));

                return Fluently.Configure()
                               .Database(cfg.ShowSql())
                               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ServerMapiranja>())
                               .BuildSessionFactory();
                //Nema potrebe da navodimo sva mapiranja zbog ove metode AddFromAssemblyOf 
                //jer ce on da pokupi sva maprianja iz namespace-a Entiteti
            }
            catch(Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
                return null;
            }
        }
    }
}
