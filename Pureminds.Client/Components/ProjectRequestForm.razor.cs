using Microsoft.AspNetCore.Components.Forms;

namespace Pureminds.Client.Components;

public partial class ProjectRequestForm
{
    private ProjectRequest source = new();
    List<ProvidedProvision>? providedProvisions;
    bool isSubmittedSuccessfully = false;
    bool isSubmitButtonPressed = false;
    private string submittedMessage = string.Empty;
    private string successMessage = "Your project request was successfully submitted!";
    private int charIndex = 0;
    protected override async Task OnInitializedAsync()
    {
        try
        {
            providedProvisions = await _client.GetFromJsonAsync<List<ProvidedProvision>>("api/providedprovisions");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        await base.OnInitializedAsync();
    }
    private async Task HandleValidSubmit()
    {
        try
        {
            isSubmitButtonPressed = true;
            await _client.PostAsJsonAsync<ProjectRequest>("api/ProjectRequests", source);
            isSubmittedSuccessfully = true;
            await StartTypeWriterEffect(successMessage);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            isSubmitButtonPressed = false;
        }
    }
    private async Task StartTypeWriterEffect(string text)
    {
        submittedMessage = string.Empty;
        charIndex = 0;

        while (charIndex < text.Length)
        {
            submittedMessage += text[charIndex];
            charIndex++;
            StateHasChanged();
            await Task.Delay(50);
        }
    }
    private async Task HandleFileUpload(InputFileChangeEventArgs e)
    {
        try
        {

            var file = e.File;
            const long maxAllowedSize = 5 * 1024 * 1024;

            if (!(file.Size > maxAllowedSize))
            {
                var buffer = new byte[file.Size];

                int? id = await file.OpenReadStream(maxAllowedSize).ReadAsync(buffer);
                source.ProjectRequestAttachment = new Attachment();
                source.ProjectRequestAttachment.Content = buffer;

                source.ProjectRequestAttachment.Content = buffer;
                source.ProjectRequestAttachment.FileName = file.Name;
                source.ProjectRequestAttachment.AttachmentAttribute = "Project Brief file";
                source.ProjectRequestAttachment.FileType = "." + file.Name.Split('.').Last();
                Console.WriteLine($"{source.ProjectRequestAttachment.FileName}");
            }
            else
            {
                Console.WriteLine("Exceeded Max Allowed File Size");
            }
        }
        catch(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}
