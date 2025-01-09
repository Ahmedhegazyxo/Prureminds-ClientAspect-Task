
namespace Pureminds.Client.Pages;

public partial class Home
{
    GeneralSetting? generalSetting = new GeneralSetting();
    List<RelevantQuestion>? relevantQuestions;
    protected override async Task OnInitializedAsync()
    {
        try
        {
            List<GeneralSetting>? generalSettings = await _client.GetFromJsonAsync<List<GeneralSetting>>("api/GeneralSettings");
            relevantQuestions = await _client.GetFromJsonAsync<List<RelevantQuestion>>("api/relevantQuestions");
            generalSetting = generalSettings.FirstOrDefault();
            if (generalSettings is null)
                throw new Exception("General Settings are not set");
        }
        catch (Exception exception)
        {
        }
        await base.OnInitializedAsync();
    }
    private void  NavigateToQuestion(int id)
    {
        _nvmgr.NavigateTo($"/relevantquestions/{id}");
    }
}
