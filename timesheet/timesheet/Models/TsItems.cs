using SQLite;
using System;

namespace timesheet.Models
{
    [Table("TsItems")]
    public class TsItems
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }
        public bool ConfirmedStatus { get; set; }
        public bool RefusedStatus { get; set; }
        public DateTime Date { get; set; }
    }
}
