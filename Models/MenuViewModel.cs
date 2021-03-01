using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Models
{
    public class MenuViewModel
    {
        public int RepositoryId { get; set; }
        public string RepositoryName { get; set; }
        public List<BranchViewModel> Branches { get; set; }
    }

    public class BranchViewModel
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
