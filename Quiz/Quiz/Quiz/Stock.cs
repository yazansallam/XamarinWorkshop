using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    [Table("Items")]
    public class Stock: ViewModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(8)]
        public Int32 DbRichtigeAntworte { get; set; }
        public Int32 FalscheAntworte { get; set; }
        public Int32 Übersprungen { get; set; }


        public static void DoSomeDataAccess()
        {
            Console.WriteLine("Creating database, if it doesn't already exist");  
            
           
            if (sqliteconnection.db.Table<Stock>().Count() == 0)
            {
                // only insert the data if it doesn't already exist
                var newStock = new Stock();
                newStock.DbRichtigeAntworte = newStock.RichtingAntwort;
                sqliteconnection.db.Insert(newStock);
                newStock = new Stock();
                newStock.FalscheAntworte = newStock.FalscheAntwort;
                sqliteconnection.db.Insert(newStock);
                newStock = new Stock();
                newStock.Übersprungen = newStock.Übersprungen;
                sqliteconnection.db.Insert(newStock);
            }
            Console.WriteLine("Reading data");
            var table = sqliteconnection.db.Table<Stock>();
        }

    }
}
