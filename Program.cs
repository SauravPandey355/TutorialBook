using Microsoft.EntityFrameworkCore;
using TutorialBook.Models;

var builder = WebApplication.CreateBuilder(args);

//Add database
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TutorialBookDB")));
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors(x => x
  .AllowAnyMethod()
  .AllowAnyHeader()
  .SetIsOriginAllowed(origin => true) // allow any origin
  .AllowCredentials());
app.UseRouting();
app.MapControllerRoute(name: "default",
    pattern:"{controller = Main}/(action = Index)/{id?}"
    );
app.UseAuthorization();

app.MapRazorPages();

app.Run();
