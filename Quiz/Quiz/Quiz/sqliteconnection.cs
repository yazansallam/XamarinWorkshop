using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Quiz
{
   public class StatistikDatenbank
    {
        readonly SQLiteConnection db;

       public StatistikDatenbank(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Statistik>();
        }

        public int SaveStatistik(Statistik stat)
        {
            stat.Id = 0;
            return db.InsertOrReplace(stat);            
        }

        public Statistik LoadStatistik()
        {
            return db.Table<Statistik>().FirstOrDefault();
        }
    }
}
