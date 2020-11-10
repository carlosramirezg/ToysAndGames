using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToysApi.Models;
using ToysDatabase;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;

namespace ToysApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers().AddNewtonsoftJson();
			services.AddScoped<IRepository<Toy>, ToysRepository>();

			services.AddCors(options =>
			{
				options.AddPolicy(
				  "CorsPolicy",
				  builder => 
				      builder
					  .WithOrigins("http://localhost:4200")
					  .AllowAnyHeader()
					  .AllowAnyMethod()
					  .AllowCredentials()				 
				  );
			});

			services.AddDbContext<ToysContext>(options => options.UseInMemoryDatabase(databaseName: "Toys"));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			
			app.UseCors("CorsPolicy");

			app.UseRouting();				

			app.UseAuthorization();
		
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
