using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOAP2JSON.Model
{
    public class LogData1
    {
        public LogData1()
        {
            this.InsertDate = DateTime.Now;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime? InsertDate { get; set; }

        public virtual ICollection<LogData2> LogData2s { get; set; }

    }
}
