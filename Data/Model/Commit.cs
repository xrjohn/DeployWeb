using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Data.Model
{
    public class Commit
    {
        public long PayloadId { get; set; }
        [StringLength(100)]
        public string Id { get; set; }
        public PayloadUser Committer { get; set; }
        [StringLength(500)]
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public PayloadUser Author { get; set; }
        [StringLength(100)]
        public string Url { get; set; }
        public string Added { get; set; }
        public string Removed { get; set; }
        public string Modified { get; set; }
    }
}
