using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SOAP2JSON.Model;

namespace SOAP2JSON.Data
{
    public class ValuesContext:DbContext
    {
        public ValuesContext(DbContextOptions<ValuesContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<LogData1> LogData1s { get; set; }
        public DbSet<LogData2> LogData2s { get; set; }
    }
}
