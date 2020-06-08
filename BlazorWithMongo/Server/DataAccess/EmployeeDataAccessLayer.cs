using BlazorWithMongo.Server.Interface;
using BlazorWithMongo.Shared.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BlazorWithMongo.Server.DataAccess
{
    public class EmployeeDataAccessLayer : IEmployee
    {
        private EmployeeDBContext db;

        public EmployeeDataAccessLayer(EmployeeDBContext _db)
        {
            db = _db;
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                return db.EmployeeRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                db.EmployeeRecord.InsertOne(employee);
            }
            catch
            {
                throw;
            }
        }


        public Employee GetEmployeeData(string id)
        {
            try
            {
                FilterDefinition<Employee> filterEmployeeData = Builders<Employee>.Filter.Eq("Id", id);

                return db.EmployeeRecord.Find(filterEmployeeData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                db.EmployeeRecord.ReplaceOne(filter: g => g.Id == employee.Id, replacement: employee);
            }
            catch
            {
                throw;
            }
        }

        public void DeleteEmployee(string id)
        {
            try
            {
                FilterDefinition<Employee> employeeData = Builders<Employee>.Filter.Eq("Id", id);
                db.EmployeeRecord.DeleteOne(employeeData);
            }
            catch
            {
                throw;
            }
        }
       
    }
}
