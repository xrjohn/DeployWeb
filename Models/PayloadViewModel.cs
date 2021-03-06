﻿using DeployWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Models
{
    public class PayloadViewModel
    {
        public long Id { get; set; }
        public int RepositoryId { get; set; }
        public string RepositoryFullName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
    }

}
