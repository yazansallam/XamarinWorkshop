using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Quiz
{
   static  class sqliteconnection
    {
       
        public static SQLiteConnection db { get; }

       static sqliteconnection()
        {
            var dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            "ormdemo.db3");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Stock>();
        }                       
    }
}
