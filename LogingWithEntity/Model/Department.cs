using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogingWithEntity.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserVS> Users { get; set; } // один депортамент ко многим юзерам
    }
}
