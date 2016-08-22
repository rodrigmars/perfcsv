using ErikEJ.SqlCe;
using perfcsv.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfcsv
{
    class BulkInsert
    {
        //Install-Package LumenWorks.Framework.IO
        //Install-Package ErikEJ.SqlCeBulkCopy

        //public void Execute(ICollection<Estoque> list)
        //{
        //    using (var bcp = new SqlCeBulkCopy(db.Database.Connection.ConnectionString))
        //    {
        //        bcp.DestinationTableName = "Students";
        //        bcp.WriteToServer(students);
        //        sw.Stop();

        //        Console.WriteLine(
        //            "Saved {0} entities using SqlCeBulkCopy in {1}", students.Count, sw.Elapsed.ToString());
        //    }
        //}

    }
}
