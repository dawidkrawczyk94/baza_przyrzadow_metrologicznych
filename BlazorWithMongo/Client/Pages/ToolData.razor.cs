using BlazorWithMongo.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWithMongo.Client.Pages
{
    public class ToolDataModel : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }
        protected List<Employee> empList = new List<Employee>();
        protected List<Tool> toolList = new List<Tool>();
        protected Tool tool = new Tool();
        protected List<Tool> expiredtoolList = new List<Tool>();

        protected string SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetToolList();
        }

        protected async Task GetToolList()
        {
            toolList = await Http.GetJsonAsync<List<Tool>>("api/Tool");
            expiredtoolList.Clear();
            foreach (var tool in toolList)
            {
                if (tool.data_nastepnej_kontroli < DateTime.Today)
                {
                    expiredtoolList.Add(tool);
                }
            }
        }
        protected async Task SearchTool()
        {
            List<Tool> temptoolList = new List<Tool>();
            await GetToolList();
            if (!string.IsNullOrEmpty(SearchString))
            {
                foreach (var tool in toolList)
                {
                    if (tool.nazwa.Contains(SearchString))
                    {
                        temptoolList.Add(tool);
                    }

                    if (tool.numer_przyrzadu.Contains(SearchString))
                    {
                        temptoolList.Add(tool);
                    }

                    if (tool.wlasciciel.Contains(SearchString))
                    {
                        temptoolList.Add(tool);
                    }
                }
                toolList = temptoolList;

            }
        }

        protected async Task SearchExpiredTool()
        {
            List<Tool> temptoolList = new List<Tool>();
            await ExpiredTools();
            if (!string.IsNullOrEmpty(SearchString))
            {
                foreach (var tool in expiredtoolList)
                {
                    if (tool.nazwa.Contains(SearchString))
                    {
                        temptoolList.Add(tool);
                    }

                    if (tool.numer_przyrzadu.Contains(SearchString))
                    {
                        temptoolList.Add(tool);
                    }

                    if (tool.wlasciciel.Contains(SearchString))
                    {
                        temptoolList.Add(tool);
                    }
                }
                expiredtoolList = temptoolList;

            }
        }

        protected async Task ExpiredTools()
        {
            toolList = expiredtoolList;
        }

            protected void DeleteConfirm(string ID)
        {
            tool = toolList.FirstOrDefault(x => x.Id == ID);
        }

        protected async Task DeleteTool(string toolID)
        { 
            await Http.DeleteAsync("api/Tool/" + toolID);
            await GetToolList();
        }
    }
}
