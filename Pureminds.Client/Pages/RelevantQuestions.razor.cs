using Microsoft.AspNetCore.Components;
using static System.Net.Mime.MediaTypeNames;

namespace Pureminds.Client.Pages;

public partial class RelevantQuestions
{
    [Parameter]
    public int Id { get; set; }
    bool isNotFoundSource = false;
    RelevantQuestion? relevantQuestion;
    private string questionAnswer;
    private int charIndex = 0;
    protected override async Task OnInitializedAsync()
    {
        try
        {
            relevantQuestion = await _client.GetFromJsonAsync<RelevantQuestion>($"api/RelevantQuestions/GetById/{Id}");
            if(relevantQuestion is not null)
            {
                await StartTypeWriterEffect(relevantQuestion.Answer);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            isNotFoundSource = true;    
        }
        await base.OnInitializedAsync();
    }
    private async Task StartTypeWriterEffect(string text)
    {
        questionAnswer = string.Empty;
        charIndex = 0;

        while (charIndex < text.Length)
        {
            questionAnswer += text[charIndex];
            charIndex++;
            StateHasChanged(); 
            await Task.Delay(25); 
        }
    }
}
