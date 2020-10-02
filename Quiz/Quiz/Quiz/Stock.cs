using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    [Table("Items")]
    public class Statistik
    {
        [PrimaryKey, Column("_id")]
        public int Id { get; set; }        
        public Int32 DbRichtigeAntworte { get; set; }
        public Int32 FalscheAntworte { get; set; }
        public Int32 Übersprungen { get; set; }        

    }
}
