namespace Pureminds.Client.Layout;

public partial class Navbar
{
    private async Task NavigateToStartAProject()
    {
        _nvmgr.NavigateTo("/StartAProject");
    }
}
