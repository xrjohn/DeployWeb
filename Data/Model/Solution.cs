using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Data.Model
{
    [Table("t_solution")]
    public class Solution : Entity<int>
    {
        [StringLength(200)]
        public string SolutionName { get; set; }
        [StringLength(100)]
        public string FtpAddress { get; set; }
        [StringLength(50)]
        public string FtpAccount { get; set; }
        [StringLength(50)]
        public string FtpPassword { get; set; }
        public int BranchId { get; set; }
    }
}
