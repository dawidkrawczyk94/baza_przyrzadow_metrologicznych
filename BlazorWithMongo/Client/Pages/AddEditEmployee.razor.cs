using BlazorWithMongo.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWithMongo.Client.Pages
{
    public class AddEditEmployeeModel : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        [Parameter]
        public string empID { get; set; }
        protected string Title = "Dodaj";
        public Employee emp = new Employee();
        protected List<Cities> cityList = new List<Cities>();



        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(empID))
            {
                Title = "Modyfikuj";
                emp = await Http.GetJsonAsync<Employee>("/api/Employee/" + empID);
            }
        }

        protected async Task SaveEmployee()
        {
            if (emp.Id != null)
            {
                await Http.SendJsonAsync(HttpMethod.Put, "api/Employee/", emp);
            }
            else
            {
                await Http.SendJsonAsync(HttpMethod.Post, "/api/Employee/", emp);
            }
            Cancel();
        }

        public void Cancel()
        {
            UrlNavigationManager.NavigateTo("/employeerecords");
        }
    }
}
