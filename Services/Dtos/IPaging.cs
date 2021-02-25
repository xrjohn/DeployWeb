using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Services.Dtos
{
    public class IPaging
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string OrderBy { get; set; }
        public bool Asc { get; set; }
    }
}
