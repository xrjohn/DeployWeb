using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Data.Model
{
    [Table("t_branch")]
    public class Branch
    {
        [StringLength(100)]
        public string Id { get; set; }
        public int RepositoryId { get; set; }
        [StringLength(200)]
        public string Ref { get; set; }
        [StringLength(100)]
        public string BranchName { get; set; }

    }
}
