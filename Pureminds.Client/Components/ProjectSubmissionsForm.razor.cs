using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Pureminds.Client.Pages;

namespace Pureminds.Client.Components;

public partial class ProjectSubmissionsForm
{
    [Parameter] public ProjectRequest? Source { get; set; } = new();
    [Parameter] public EventCallback OnCancelCallback { get; set; }
    [Parameter] public string Title { get; set; } = "Details";
    [Parameter] public OperationType OperationType { get; set; } = OperationType.Info;
    private bool isSourceLoading = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Source = await _client.GetFromJsonAsync<ProjectRequest>($"api/ProjectRequests/GetProjectRequestWithIncludes/{Source.Id}");
            isSourceLoading = false;
        }
        catch(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        await base.OnInitializedAsync();
    }
    private async Task OnValidSubmit()
    {
    }

    private async Task OnCancel()
    {
        await OnCancelCallback.InvokeAsync();
    }
    private async Task DownloadAttachment(Attachment attachment)
    {
        var fileBase64 = Convert.ToBase64String(attachment.Content);

        await JS.InvokeVoidAsync("downloadFileFromBytes", attachment.FileName, fileBase64);
    }
}
