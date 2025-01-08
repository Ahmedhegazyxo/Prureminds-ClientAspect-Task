namespace Pureminds.Server;

public class GeneralSettingService : BaseService<GeneralSetting>, IGeneralSettingService
{
    MigrationsDbContext _context;
    public GeneralSettingService(MigrationsDbContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<GeneralSetting> Create(GeneralSetting entity)
    {
        try
        {

            List<GeneralSetting>? generalSettings = await Read();
            if (generalSettings is null || generalSettings.Count() == 0)
            {
                return await base.Create(entity);
            }
            else
            {
                throw new Exception("A General Setting Record is already in database");
            }
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
}
