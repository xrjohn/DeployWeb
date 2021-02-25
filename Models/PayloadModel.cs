using DeployWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Models
{
    public class PayloadModel
    {
        public string Ref { get; set; }
        public Repository Repository { get; set; }
        public string Action { get; set; }
        public string Branch { get; set; }
        public GitUserModel Pusher { get; set; }
        public CommitModel Head_commit { get; set; }
        public List<CommitModel> Commits { get; set; }
    }

    public class GitUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }

    public class CommitModel
    {
        public string Id { get; set; }
        public GitUserModel Committer { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public GitUserModel Author { get; set; }
        public string Url { get; set; }
        public List<string> Added { get; set; }
        public List<string> Removed { get; set; }
        public List<string> Modified { get; set; }
    }
}
