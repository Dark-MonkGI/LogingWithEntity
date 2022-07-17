using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LogingWithEntity.Model
{
    public class UserVS
    {
        [Key]
        public int Id { get; set; }
        public string Loogin { get; set; }
        public string Password { get; set; }
    }
}
