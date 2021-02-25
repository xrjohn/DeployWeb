using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Data.Model
{
    [Table("t_payload")]
    public class Payload : CreationEntity<long>
    {
        [StringLength(100)]
        public string Ref { get; set; }
        public int RepositoryId { get; set; }
        [StringLength(100)]
        public string BranchId { get; set; }
        [StringLength(20)]
        public string Action { get; set; }
        [StringLength(100)]
        public string PusherName { get; set; }
        [StringLength(100)]
        public string PusherEmail { get; set; }
        [StringLength(100)]
        public string Head_commitId { get; set; }
        public string CommitIds { get; set; }
    }
}
