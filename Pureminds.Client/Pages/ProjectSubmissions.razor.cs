using Microsoft.JSInterop;

namespace Pureminds.Client.Pages;

public partial class ProjectSubmissions
{
    private async Task DownloadAttachment(int attachmentId)
    {
        try
        {
            // Fetch the attachment content from the API
            var response = await _client.GetAsync($"api/attachments/download/{attachmentId}");

            if (response.IsSuccessStatusCode)
            {
                // Get the file content as a byte array
                var content = await response.Content.ReadAsByteArrayAsync();
                var base64Content = Convert.ToBase64String(content);

                // Extract the file name from the Content-Disposition header (if available)
                var fileName = response.Content.Headers.ContentDisposition?.FileNameStar
                               ?? response.Content.Headers.ContentDisposition?.FileName
                               ?? "DownloadedFile";

                // Invoke the JS function to download the file
                await _jsruntime.InvokeVoidAsync("downloadFileFromBytes", fileName, base64Content);
            }
            else
            {
                Console.Error.WriteLine($"Failed to fetch the attachment. Status Code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error downloading attachment: {ex.Message}");
        }
    }

}
