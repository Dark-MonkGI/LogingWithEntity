using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LogingWithEntity.Model
{
    internal class initializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            //base.Seed(context);

            context.MyEntitiesTable.Add(new UserVS { Loogin = "Admin", Password = "sa" });
            context.SaveChanges();
        }
    }
}
