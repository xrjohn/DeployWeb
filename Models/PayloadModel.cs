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
        public string Repository { get; set; }
        public string Action { get; set; }
        public PayloadUser Pusher { get; set; }
        public CommitModel Head_commit { get; set; }
        public List<CommitModel> Commits { get; set; }
    }

    public class CommitModel
    {
        public string Id { get; set; }
        public PayloadUser Committer { get; set; }
        public string Message { get; set; }
        public string Timestamp { get; set; }
        public PayloadUser Author { get; set; }
        public string Url { get; set; }
        public List<string> Added { get; set; }
        public List<string> Removed { get; set; }
        public List<string> Modified { get; set; }
    }
}
