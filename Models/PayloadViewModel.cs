using DeployWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Models
{
    public class PayloadViewModel
    {
        public long Id { get; set; }
        public RepositoryViewModel Repository { get; set; }
    }

    public class RepositoryViewModel : Repository
    {
        public List<RefViewModel> Refs { get; set; }
    }

    public class RefViewModel
    {
        public string Ref { get; set; }
        public string Branch { get; set; }
        public List<CommitModel> Commits { get; set; }
    }

    public class CommitViewModel : CommitModel
    {

    }

}
