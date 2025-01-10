using Microsoft.AspNetCore.Components;

namespace Pureminds.Client.Components;

public partial class PuremindsButton
{
    [Parameter]
    public string LongButtonText { get; set; }
    [Parameter]
    public string ClassName { get; set; }
    [Parameter]
    public bool IsHideInSmallScreens { get; set; }
    [Parameter]
    public EventCallback Clicked { get; set; }
    private async Task ButtonClicked()
    {
        await Clicked.InvokeAsync();
    }
}
