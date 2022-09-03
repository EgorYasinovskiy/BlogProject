using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddIdentityServer()
	.AddConfigurationStore(options =>
	{
		options.ConfigureDbContext = b =>
		b.UseNpgsql(builder.Configuration.GetConnectionString("IdentityServerDB"),
		sql => sql.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
	})
	.AddOperationalStore(options =>
   {
	   options.ConfigureDbContext = b =>
		 b.UseNpgsql(builder.Configuration.GetConnectionString("IdentityServerDB"),
		 sql => sql.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));

   });

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
