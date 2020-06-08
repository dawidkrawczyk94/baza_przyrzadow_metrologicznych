using BlazorWithMongo.Server.Interface;
using BlazorWithMongo.Shared.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BlazorWithMongo.Server.DataAccess
{
    public class ToolDataAccessLayer : ITool
    {
        private ToolDBContext db;

        public ToolDataAccessLayer(ToolDBContext _db)
        {
            db = _db;
        }

    
        public List<Tool> GetAllTool()
        {
            try
            {
                return db.ToolRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

    
        public void AddTool(Tool tool)
        {
            try
            {
                db.ToolRecord.InsertOne(tool);
            }
            catch
            {
                throw;
            }
        }


      
        public Tool GetToolData(string id)
        {
            try
            {
                FilterDefinition<Tool> filterToolData = Builders<Tool>.Filter.Eq("Id", id);

                return db.ToolRecord.Find(filterToolData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateTool(Tool tool)
        {
            try
            {
                db.ToolRecord.ReplaceOne(filter: g => g.Id == tool.Id, replacement: tool);
            }
            catch
            {
                throw;
            }
        }

        public void DeleteTool(string id)
        {
            try
            {
                FilterDefinition<Tool> toolData = Builders<Tool>.Filter.Eq("Id", id);
                db.ToolRecord.DeleteOne(toolData);
            }
            catch
            {
                throw;
            }
        }
        
    }
}
