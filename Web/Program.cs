using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Web;
using Web.Persistence;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var connectionString = builder.Configuration.GetConnectionString("WebDb");

builder.Services.AddDbContext<WebDbContext>(option =>
    option.UseNpgsql(connectionString));



var option = new DbContextOptionsBuilder<WebDbContext>();

option.UseNpgsql(connectionString);

var context = new WebDbContext(option.Options);

context.Database.EnsureCreated();

var app = builder.Build();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
