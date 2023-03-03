using Core.Contracts;
using Core.Managers;
using Data.AccessServices;
using Data.Contracts;
using Data.Providers.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IDatabaseContext, DatabaseContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<PasatiempoDatabaseContext>();
builder.Services.AddScoped<IUserTypeAccessServices, UserTypeAccessServices>();
builder.Services.AddScoped<IUserTypeManager, UserTypeManager>();
builder.Services.AddScoped<IExcelManager, ExcelManager>();
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseFileServer();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
