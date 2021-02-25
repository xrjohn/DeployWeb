using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Data.Model
{
    [Table("t_commit")]
    public class Commit
    {
        [StringLength(100)]
        public string Id { get; set; }
        [StringLength(100)]
        public string CommitterName { get; set; }
        [StringLength(100)]
        public string CommitterEmail { get; set; }
        [StringLength(100)]
        public string CommitterUserName { get; set; }
        [StringLength(500)]
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        [StringLength(100)]
        public string AuthorName { get; set; }
        [StringLength(100)]
        public string AuthorEmail { get; set; }
        [StringLength(100)]
        public string AuthorUserName { get; set; }
        [StringLength(100)]
        public string Url { get; set; }
        public string Added { get; set; }
        public string Removed { get; set; }
        public string Modified { get; set; }
        public DateTime CreationTime { get; set; }

        public Commit()
        {
            CreationTime = DateTime.Now;
        }
    }
}
