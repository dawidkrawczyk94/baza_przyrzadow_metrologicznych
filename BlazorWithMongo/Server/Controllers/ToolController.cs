using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWithMongo.Server.Interface;
using BlazorWithMongo.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorWithMongo.Server.Controllers
{
    [Route("api/[controller]")]
    public class ToolController : Controller
    {
        private readonly ITool objtool;

        public ToolController(ITool _objtool)
        {
            objtool = _objtool;
        }

        [HttpGet]
        public IEnumerable<Tool> Get()
        {
            return objtool.GetAllTool();
        }

        [HttpPost]
        public void Post([FromBody] Tool tool)
        {
            objtool.AddTool(tool);
        }

        [HttpGet("{id}")]
        public Tool Get(string id)
        {
            return objtool.GetToolData(id);
        }

        [HttpPut]
        public void Put([FromBody]Tool tool)
        {
            objtool.UpdateTool(tool);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            objtool.DeleteTool(id);
        }

    }
}
