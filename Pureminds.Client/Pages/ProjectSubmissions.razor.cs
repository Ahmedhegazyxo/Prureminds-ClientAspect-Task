using Microsoft.JSInterop;

namespace Pureminds.Client.Pages;

public partial class ProjectSubmissions
{
    private List<ProjectRequest>? submissions;

    private ProjectRequest? source;
    private bool isModalOpen = false;
    private OperationType operationType = OperationType.Add;
    private string modalTitle = "Details";
    protected override async Task OnInitializedAsync()
    {
        try
        {
            submissions = await _client.GetFromJsonAsync<List<ProjectRequest>>("api/ProjectRequests");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        await base.OnInitializedAsync();
    }
    private async void ShowForm(OperationType opType, ProjectRequest projectRequest)
    {
        source = projectRequest;
        operationType = opType;
        isModalOpen = true;
        source = projectRequest;
    }
    private async Task FormCancelled()
    {
        isModalOpen = false;
    }
}
