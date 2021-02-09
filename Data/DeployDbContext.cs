using DeployWeb.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Data
{
    public class DeployDbContext : DbContext
    {
        public DbSet<Commit> Commits { get; set; }
        public DbSet<PayloadUser> PayloadUsers { get; set; }
        public DbSet<Payload> Payloads { get; set; }
        public DbSet<Repository> Repositorys { get; set; }

        public DeployDbContext(DbContextOptions<DeployDbContext> options) : base(options)
        {

        }
    }
}
