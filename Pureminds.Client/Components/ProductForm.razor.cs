using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Pureminds.Client.Components;

public partial class ProductForm
{
    [Parameter] public Product Source { get; set; } = new();
    [Parameter] public EventCallback OnCancelCallback { get; set; }
    [Parameter] public string Title { get; set; } = "Edit Product";
    [Parameter] public OperationType OperationType { get; set; } = OperationType.Info;
    private bool isDisabled = false;
    private bool isFormLoaded = false;
    protected override async Task OnParametersSetAsync()
    {
        if (OperationType == OperationType.Delete || OperationType == OperationType.Delete)
            isDisabled = true;
        if(OperationType == OperationType.Add)
        {
            Source.ProductAttachments = new List<ProductAttachment>();
            Source.ProductAttachments.Add(new ProductAttachment
            {
                Attachment = new Attachment
                {
                    AttachmentAttribute = "Product Picture",
                }
            });
        }
        else if (OperationType == OperationType.Edit)
        {
            Source = await _client.GetFromJsonAsync<Product>($"api/products/GetById/{Source.Id}");
            if(Source.ProductAttachments is null || Source.ProductAttachments.Count() == 0)
            {
                Source.ProductAttachments = new List<ProductAttachment>();
                Source.ProductAttachments.Add(new ProductAttachment
                {
                    Attachment = new Attachment
                    {
                        AttachmentAttribute = "Product Picture",
                    }
                });
            }
        }
        isFormLoaded = true;
        await base.OnParametersSetAsync();
    }
    private async Task HandleFileUpload(InputFileChangeEventArgs e , int indexInProductAttachments)
    {
        try
        {
            var file = e.File;
            const long maxAllowedSize = 5 * 1024 * 1024;

            if (!(file.Size > maxAllowedSize))
            {
                if (!(file.Size > maxAllowedSize))
                {
                    var buffer = new byte[file.Size];

                    int? id = await file.OpenReadStream(maxAllowedSize).ReadAsync(buffer);
                    Attachment attachment = new Attachment();
                    attachment.FileType = "." + file.Name.Split('.').Last();

                    Source.ProductAttachments[indexInProductAttachments].Attachment.Content = buffer;
                    Source.ProductAttachments[indexInProductAttachments].Attachment.FileName = file.Name;
                    Source.ProductAttachments[indexInProductAttachments].Attachment.FileType = "." + file.Name.Split('.').Last();

                }
                else
                {
                    Console.WriteLine("Exceeded Max Allowed File Size");
                }
            }
            else
            {
                Console.WriteLine("Exceeded Max Allowed File Size");
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private async Task<byte[]> ConvertFileToByteArray(IBrowserFile file)
    {
        using var stream = new MemoryStream();
        await file.OpenReadStream().CopyToAsync(stream);
        return stream.ToArray();
    }

    private async Task OnValidSubmit()
    {
        try
        {
            if (OperationType == OperationType.Add)
            {
                await _client.PostAsJsonAsync<Product>("api/products", Source);
            }
            else if (OperationType == OperationType.Edit)
            {
                await _client.PutAsJsonAsync<Product>("api/products", Source);
            }
            await OnCancelCallback.InvokeAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private async Task OnCancel()
    {
        await OnCancelCallback.InvokeAsync();
    }
   
}

