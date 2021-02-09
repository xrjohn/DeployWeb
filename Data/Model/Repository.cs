using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Data.Model
{
    public class Repository
    {
        public long PayloadId { get; set; }
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Full_name { get; set; }
        [StringLength(100)]
        public string Url { get; set; }

    }
}
