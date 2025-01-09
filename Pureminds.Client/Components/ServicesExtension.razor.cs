
namespace Pureminds.Client.Components;

public partial class ServicesExtension
{
    List<ProvidedProvision>? provisions;
    protected override async Task OnInitializedAsync()
    {
        try
        {
           provisions =  await _client.GetFromJsonAsync<List<ProvidedProvision>>("api/providedprovisions");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        await base.OnInitializedAsync();
    }
}
