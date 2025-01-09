namespace Pureminds.Client.Components;

public partial class CompanyProjectsExtension
{
    List<Product>? products;
    protected override async Task OnInitializedAsync()
    {
        try
        {
            products = await _client.GetFromJsonAsync<List<Product>>("api/products/GetProductsWithAttachments");
        }
        catch (Exception excpetion)
        {
            Console.WriteLine(excpetion.Message);
        }
        await InvokeAsync(StateHasChanged);
        await base.OnInitializedAsync();
    }
}
