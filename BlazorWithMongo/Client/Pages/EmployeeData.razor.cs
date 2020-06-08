using BlazorWithMongo.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWithMongo.Client.Pages
{
    public class EmployeeDataModel : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }
        protected List<Employee> empList = new List<Employee>();
        protected List<Tool> toolList = new List<Tool>();
        protected Employee emp = new Employee();
        protected string SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetEmployeeList();
            await GetToolList();
        }


        protected async Task GetEmployeeList()
        {
            empList = await Http.GetJsonAsync<List<Employee>>("api/Employee");
        }

        protected async Task GetToolList()
        {
            toolList = await Http.GetJsonAsync<List<Tool>>("api/Tool");
        }
        protected int GetToolCount(string empname)
        {
            int toolcount=0;
           foreach (var tool in toolList)
            {
                if(tool.wlasciciel == empname)
                {
                    toolcount += 1;
                }
            }
            
            return toolcount;
        }
        protected async Task SearchEmployee()
        {
            List<Employee> tempempList = new List<Employee>();
            await GetEmployeeList();
            if (!string.IsNullOrEmpty(SearchString))
            {
                foreach (var emp in empList)
                {
                    if (emp.Name.Contains(SearchString))
                    {
                        tempempList.Add(emp);
                    }

                    if (emp.dzial.Contains(SearchString))
                    {
                        tempempList.Add(emp);
                    }

                    if (emp.nrew.Contains(SearchString))
                    {
                        tempempList.Add(emp);
                    }

                }
                empList = tempempList;

            }
        }

        protected void DeleteConfirm(string ID)
        {
            emp = empList.FirstOrDefault(x => x.Id == ID);
        }

        protected async Task DeleteEmployee(string empID)
        { 
            await Http.DeleteAsync("api/Employee/" + empID);
            await GetEmployeeList();
        }
    }
}
