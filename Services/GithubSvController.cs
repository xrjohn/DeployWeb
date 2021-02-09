using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeployWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DeployWeb.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubSvController : ControllerBase
    {
        [HttpPost]
        public void Receiver(string para)
        {
            var model = JsonConvert.DeserializeObject<PayloadModel>(para);
            SavePushItems(model);
        }

        private void SavePushItems(PayloadModel model)
        {
            //TODO:
        }
    }
}
