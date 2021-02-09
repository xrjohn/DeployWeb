using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Data.Model
{
    public class Payload : CreationEntity<long>
    {
        [StringLength(100)]
        public string Ref { get; set; }
        public Repository Repository { get; set; }

        [StringLength(20)]
        public string Action { get; set; }
        public PayloadUser Pusher { get; set; }
        public Commit Head_commit { get; set; }
        public string Commits { get; set; }
    }
}
