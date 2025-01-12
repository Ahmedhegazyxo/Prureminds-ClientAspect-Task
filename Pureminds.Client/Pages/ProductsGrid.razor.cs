using Pureminds.Shared;

namespace Pureminds.Client.Pages;

public partial class ProductsGrid
{
    GeneralSetting? generalSetting = new GeneralSetting();
    private List<Product>? products;

    private Product source = new Product();
    private bool isModalOpen = false;
    private OperationType operationType = OperationType.Add;
    private string modalTitle = "Add New Product";

    protected override async Task OnInitializedAsync()
    {
        try
        {
            await LoadProducts();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        await base.OnInitializedAsync();
    }

    private void ShowForm(OperationType opType, Product product)
    {
        source = product;
        operationType = opType;
        isModalOpen = true;
        if (opType == OperationType.Add)
        {
            modalTitle = "Add new Product";
            source = product;
        }
        else if (opType == OperationType.Edit)
        {
            modalTitle = "Edit Product";
        }
        else if (opType == OperationType.Info)
        {
            modalTitle = "Details";
        }
    }

    private void FormCancelled()
    {
        isModalOpen = false;
    }
    private async void FormSubmitted()
    {
        isModalOpen = false;
        products = null;
        isModalOpen = false;
        await LoadProducts();
        await InvokeAsync(StateHasChanged);
    }
    private async Task LoadProducts()
    {
        try
        {
            products = await _client.GetFromJsonAsync<List<Product>>("api/products");
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
  
}
