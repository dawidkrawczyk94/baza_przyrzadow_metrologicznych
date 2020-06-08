using BlazorWithMongo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWithMongo.Server.Interface
{
   

    public interface ITool
    {
        public List<Tool> GetAllTool();
        public void AddTool(Tool tool);
        public Tool GetToolData(string id);
        public void UpdateTool(Tool tool);
        public void DeleteTool(string id);

    }
}
