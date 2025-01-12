using Microsoft.AspNetCore.Components;

namespace Pureminds.Client.Components;

public partial class CompanyProjectsExtension
{
    [Parameter] public bool IsInsideThePage { get; set; }
    List<Product>? products;
    protected override async Task OnInitializedAsync()
    {
        try
        {
            if (IsInsideThePage)
                products = await _client.GetFromJsonAsync<List<Product>>("api/Products");
            else
                products = await _client.GetFromJsonAsync<List<Product>>("api/Products/GetPrioritizedProducts");

        }
        catch (Exception excpetion)
        {
            Console.WriteLine(excpetion.Message);
        }
        await base.OnInitializedAsync();
    }
    private void NavigateToWork()
    {
        _nvmgr.NavigateTo("Projects");
    }
}
