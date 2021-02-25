using Dapper;
using DeployWeb.Data.Model;
using DeployWeb.Services.Dtos;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DeployWeb.Data
{
    public class DeployDbContext : DbContext
    {
        private static IConfiguration Configuration { get; }
        private static IDbConnection dbConnection = null;
        private static string _pagedSql = " Order By {0} {1} LIMIT {2} OFFSET (({3}-1) * {2})";
        private static IDbConnection DbConnection
        {
            get
            {
                if (dbConnection == null)
                {
                    dbConnection = new SqliteConnection(Configuration.GetConnectionString("Default"));
                }
                //判断连接状态
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }
                return dbConnection;
            }
        }
        public DbSet<Commit> Commits { get; set; }
        public DbSet<Payload> Payloads { get; set; }
        public DbSet<Repository> Repositorys { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<TranscationRecord> TranscationRecords { get; set; }

        public DeployDbContext(DbContextOptions<DeployDbContext> options) : base(options)
        {

        }

        public IEnumerable<T> Query<T>(string sql, params object[] sqlParas)
        {
            IEnumerable<T> dy = null;
            using (IDbConnection db = DbConnection)
            {
                db.Open();
                dy = db.Query<T>(sql, sqlParas);
                db.Close();
            }
            return dy;
        }

        public T QueryFirstOrDefault<T>(string sql, params object[] sqlParas)
        {
            T dy;
            using (IDbConnection db = DbConnection)
            {
                db.Open();
                dy = db.QueryFirstOrDefault<T>(sql, sqlParas);
                db.Close();
            }
            return dy;
        }

        public int ExecuteNonQuery(string sql, object param)
        {
            int count = 0;
            using (IDbConnection db = DbConnection)
            {
                db.Open();
                count = db.Execute(sql, param);
                db.Close();
            }
            return count;
        }

        public IEnumerable<T> PagedList<T>(string sql, IPaging page, object param = null)
        {
            IEnumerable<T> result;
            using (var db = DbConnection)
            {
                string pagedSql = string.Format(_pagedSql, page.OrderBy, page.Asc ? "Asc" : "Desc", page.PageSize, page.PageNumber);
                string lastSql = string.Format("WITH _temp_prix_pagetable AS ({0}) SELECT * FROM _temp_prix_pagetable t {1} ", sql, pagedSql);
                result = db.Query<T>(lastSql, param);
            }
            return result;
        }

    }
}
