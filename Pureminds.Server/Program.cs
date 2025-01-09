using Pureminds.Client.Pages;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services container
builder.Services.AddTransient<IGeneralSettingService, GeneralSettingService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IMediaClientService, MediaClientService>();
builder.Services.AddTransient<IRelevantQuestionService, RelevantQuestionService>();
builder.Services.AddTransient<IAttachmentService, AttachmentService>();
builder.Services.AddTransient<IProjectRequestService, ProjectRequestService>();

builder.Services.AddSingleton<IEmailService, EmailService>();


if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<MigrationsDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentConnection")));
else
    builder.Services.AddDbContext<MigrationsDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("ProductionConnection")));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();


app.MapControllers();
app.MapFallbackToFile("index.html");

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
