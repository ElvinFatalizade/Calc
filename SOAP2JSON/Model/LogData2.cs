using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOAP2JSON.Model
{
    public class LogData2
    {
        public LogData2()
        {

        }

        public LogData2(int ld, string val)
        {
            LogData1Id = ld;
            Value = val;
            this.InsertDate = DateTime.Now;
        }

        public int Id { get; set; }

        public DateTime? InsertDate { get; set; }
        [Required]
        public string Value { get; set; }

        public int LogData1Id { get; set; }

        public LogData1 LogData1 { get; set; }
    }
}
