using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeployWeb.Data;
using DeployWeb.Data.Model;
using DeployWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DeployWeb.Controllers
{
    public class ReceiverController : Controller
    {
        private readonly DeployDbContext _deployDbContext;
        public ReceiverController(DeployDbContext deployDbContext)
        {
            _deployDbContext = deployDbContext;
        }
        [HttpPost]
        public void Receiver(string para)
        {
            var setting = new JsonSerializerSettings();
            var model = JsonConvert.DeserializeObject<PayloadModel>(para, setting);
            SavePushItems(model);
        }

        private void SavePushItems(PayloadModel model)
        {
            SaveRepository(model.Repository);
            var branchId = SaveBranch(model);
            SaveRepository(model.Repository);
            SaveCommits(model.Commits);
            //TODO:Map to Payload
            var payload = new Payload
            {
                Ref = model.Ref,
                BranchId = branchId,
                Head_commitId = model.Head_commit.Id,
                PusherEmail = model.Pusher.Email,
                PusherName = model.Pusher.Name,
                RepositoryId = model.Repository.Id,
                Action = model.Action,
                CommitIds = string.Join(',', model.Commits.Select(p => p.Id).ToList())
            };

            _deployDbContext.Add(payload);
            _deployDbContext.SaveChanges();
        }

        private void SaveRepository(Repository model)
        {
            if (_deployDbContext.Repositorys.Any(p => p.Id == model.Id)) return;
            _deployDbContext.Repositorys.Add(model);
        }

        private string SaveBranch(PayloadModel model)
        {
            var branch = new Branch
            {
                Id = model.Repository.Id + "-" + model.Ref,
                Ref = model.Ref,
                BranchName = model.Ref.Substring(model.Ref.LastIndexOf('/') + 1),
                RepositoryId = model.Repository.Id
            };
            if (_deployDbContext.Branches.Any(p => p.Id == branch.Id && p.Ref.ToLower().Equals(model.Ref.ToLower()))) return string.Empty;
            _deployDbContext.Branches.Add(branch);
            return branch.Id;
        }

        private void SaveCommits(List<CommitModel> models)
        {
            var commits = new List<Commit>();
            foreach (var model in models)
            {
                var commit = new Commit
                {
                    Id = model.Id,
                    Message = model.Message,
                    Timestamp = model.Timestamp,
                    Url = model.Url,
                    Added = string.Join(',', model.Added),
                    Modified = string.Join(',', model.Modified),
                    Removed = string.Join(',', model.Removed),
                    AuthorEmail = model.Author.Email,
                    AuthorName = model.Author.Name,
                    AuthorUserName = model.Author.UserName,
                    CommitterEmail = model.Committer.Email,
                    CommitterName = model.Committer.Name,
                    CommitterUserName = model.Committer.UserName
                };
                if (commits.Any(p => p.Id == model.Id)) continue;
                if (_deployDbContext.Commits.Any(p => p.Id.ToLower().Equals(model.Id.ToLower()))) continue;
                commits.Add(commit);
            }
            _deployDbContext.Add(commits);
        }

    }
}
