using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Data.Model
{
    [Table("t_transcationrecord")]
    public class TranscationRecord : CreationEntity<int>
    {
        public int FromSolutionId { get; set; }
        public int ToSolutionId { get; set; }
        public string AddLists { get; set; }
        public string ModifyLists { get; set; }
        public string RemoveLists { get; set; }
        public bool SoftRemove { get; set; } = false;
    }
}
