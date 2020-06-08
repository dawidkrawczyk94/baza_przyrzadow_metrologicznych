using BlazorWithMongo.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWithMongo.Client.Pages
{
    public class AddEditToolModel : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        [Parameter]
        public string toolID { get; set; }
        protected string Title = "Dodaj";
        public Tool tool = new Tool();
        public System.DateTime today_date = new System.DateTime();
        protected List<Employee> empList = new List<Employee>();
        
        protected override async Task OnInitializedAsync()
        {
            if (tool.data_nastepnej_kontroli == DateTime.MinValue)
            {
                tool.data_nastepnej_kontroli = DateTime.Today;
            }

            if (tool.data_ostatniej_kontroli == DateTime.MinValue)
            {
                tool.data_ostatniej_kontroli = DateTime.Today;
            }

            await GetEmployeeList();
        }


        protected async Task GetEmployeeList()
        {
            empList = await Http.GetJsonAsync<List<Employee>>("api/Employee");
        }

        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(toolID))
            {
                Title = "Modyfikuj";
                tool = await Http.GetJsonAsync<Tool>("/api/Tool/" + toolID);
            }
        }

        //protected async Task GetCityList()
        //{
        //    cityList = await Http.GetJsonAsync<List<Cities>>("api/Employee/GetCities");
        //}
        protected async Task SaveTool()
        {
            if (tool.Id != null)
            {
                await Http.SendJsonAsync(HttpMethod.Put, "api/Tool/", tool);
            }
            else
            {
                await Http.SendJsonAsync(HttpMethod.Post, "/api/Tool/", tool);
            }
            Cancel();
        }

        public void Cancel()
        {
            UrlNavigationManager.NavigateTo("/toolrecords");
        }
    }
}
