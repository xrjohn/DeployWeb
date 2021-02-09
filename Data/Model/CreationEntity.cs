using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Data.Model
{
    public class CreationEntity<T> : Entity<T>
    {
        public DateTime CreationTime { get; set; }

        public CreationEntity()
        {
            CreationTime = DateTime.Now;
        }
    }
}
