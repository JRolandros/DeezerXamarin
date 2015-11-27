using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Interop;
using System.IO;
using OneDeezer.Services;
using System.Diagnostics;

namespace OneDeezer.Data
{
    public class OneDBContext : SQLiteConnection
    {

        public static string DatabaseFolder { get; set; }
        public static ISQLitePlatform sqlitePlateform { get; set; }

        private static string DatabaseFile
        {
            get
            {
                return Path.Combine(DatabaseFolder, "OneDeezerDB.db");
            }
        }


        public OneDBContext(): base(sqlitePlateform, DatabaseFolder)
        {
            ExecuteScalar<string>("PRAGMA journal_mode=WAL;");
            try
            {
                CreateTable<Artist>();
            }
            catch (Exception)
            {

                Debug.WriteLine("Database not created !");
            }
        }
    }
}
