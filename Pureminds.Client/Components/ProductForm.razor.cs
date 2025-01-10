using Microsoft.AspNetCore.Components;

namespace Pureminds.Client.Components;

public partial class ProductForm
{
    [Parameter] public Product Source { get; set; } = new();
    [Parameter] public EventCallback OnCancelCallback { get; set; }
    [Parameter] public string Title { get; set; } = "Edit Product";
    [Parameter] public OperationType OperationType { get; set; } = OperationType.Info;
    private bool isDisabled = false;
    protected override async Task OnParametersSetAsync()
    {
        if (OperationType == OperationType.Delete || OperationType == OperationType.Delete)
            isDisabled = true;
        await base.OnParametersSetAsync();
    }
    private async Task OnValidSubmit()
    {
        try
        {
            if(OperationType == OperationType.Add)
            {
                 await _client.PostAsJsonAsync<Product>("api/products", Source);
            }
            else if (OperationType == OperationType.Edit)
            {
                await _client.PutAsJsonAsync<Product>("api/products", Source);
            }
            await OnCancelCallback.InvokeAsync();    
        }
        catch(Exception exception) 
        {
            Console.WriteLine(exception.Message);
        }
    }

    private async Task OnCancel()
    {
        await OnCancelCallback.InvokeAsync();
    }
}
