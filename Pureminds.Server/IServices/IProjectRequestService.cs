namespace Pureminds.Server;

public interface IProjectRequestService : IBaseService<ProjectRequest> 
{
    Task<ProjectRequest> ReadByIdWithIncludes(int id);
}
