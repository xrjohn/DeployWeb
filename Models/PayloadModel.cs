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
        public User Pusher { get; set; }
        public Commit Head_commit { get; set; }
        public List<Commit> Commits { get; set; }
    }

    public class Commit
    {
        public string Id { get; set; }
        public User Committer { get; set; }
        public string Message { get; set; }
        public string Timestamp { get; set; }
        public User Author { get; set; }
        public string Url { get; set; }
        public List<string> Added { get; set; }
        public List<string> Removed { get; set; }
        public List<string> Modified { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
