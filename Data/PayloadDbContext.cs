using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Data
{
    public class PayloadDbContext : DbContext
    {
        public PayloadDbContext(DbContextOptions<PayloadDbContext> options) : base(options)
        {

        }
    }
}
