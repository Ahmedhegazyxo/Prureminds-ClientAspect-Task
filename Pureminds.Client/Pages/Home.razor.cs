
namespace Pureminds.Client.Pages;

public partial class Home
{
    GeneralSetting? generalSetting = new GeneralSetting();
    protected override async Task OnInitializedAsync()
    {
        try
        {
            List<GeneralSetting>? generalSettings = await _client.GetFromJsonAsync<List<GeneralSetting>>("api/GeneralSettings");
            generalSetting = generalSettings.FirstOrDefault();
            if (generalSettings is null)
                throw new Exception("General Settings are not set");
        }
        catch (Exception exception)
        {
        }
        await base.OnInitializedAsync();
    }
}
