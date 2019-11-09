using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SOAP2JSON.Data;

namespace SOAP2JSON
{
    public static class Ex
    {
        public async static Task AddLog(this ValuesContext db, int type, string message)
        {
            await db.LogData2s.AddAsync(new Model.LogData2
            {
                InsertDate = DateTime.Now,
                LogData1Id = type,
                Value = message
            });

            await db.SaveChangesAsync();
        }
    }
}
