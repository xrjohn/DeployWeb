using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Data.Model
{
    [Table("t_repository")]
    public class Repository : Entity<int>
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Full_Name { get; set; }
        [StringLength(100)]
        public string Url { get; set; }
    }
}
