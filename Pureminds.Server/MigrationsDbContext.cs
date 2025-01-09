
namespace Pureminds.Server;

public class MigrationsDbContext : DbContext
{
    public MigrationsDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Pureminds ;Integrated Security=True; Encrypt=False");

        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RelevantQuestionEntityConfigurations());
        modelBuilder.ApplyConfiguration(new ProductEntityConfigurations());
        modelBuilder.ApplyConfiguration(new MediaClientEntityConfigurations());
        modelBuilder.ApplyConfiguration(new GeneralSettingEntityConfigurations());
        modelBuilder.ApplyConfiguration(new ProductAttachmentConfigurations());
        modelBuilder.ApplyConfiguration(new AttachmentEntityConfigurations());
        modelBuilder.ApplyConfiguration(new ProjectRequestEntityConfigurations());
        
        base.OnModelCreating(modelBuilder);
    }
}
