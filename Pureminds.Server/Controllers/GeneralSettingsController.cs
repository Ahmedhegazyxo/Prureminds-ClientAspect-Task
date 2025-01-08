namespace Pureminds.Server;

public class GeneralSettingsController : BaseController<GeneralSetting>
{
    IGeneralSettingService _service;
    public GeneralSettingsController(IGeneralSettingService service) : base(service)
    {
        _service = service;
    }
}
