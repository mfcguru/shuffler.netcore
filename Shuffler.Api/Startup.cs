using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Shuffler.Api.Hubs;
using Shuffler.Domain;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace Shuffler.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;

			AutoMapperConfiguration.Configure();
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMediatR(new Assembly[] {
				Assembly.GetExecutingAssembly()
			});

			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder => builder
				.WithOrigins("http://localhost:3000", "http://localhost:4200", "http://localhost:8080")
				.AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials());
			});

			services.AddSignalR();

			services.AddControllers();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shuffler", Version = "v1" });
				c.CustomSchemaIds(x => x.FullName);
				c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
				c.OperationFilter<SecurityRequirementsOperationFilter>(false);
			});

			services.AddScoped<IDeck, Deck>();
			services.AddScoped<Hub, DeckHub>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors("CorsPolicy");

			app.UseAuthentication();

			app.UseSwaggerUI(o =>
			{
				o.RoutePrefix = "api";
				o.SwaggerEndpoint("/swagger/v1/swagger.json", "Version 1");
				o.OAuthClientId("swagger-ui");
				o.OAuthClientSecret("swagger-ui-secret");
				o.OAuthRealm("swagger-ui-realm");
				o.OAuthAppName("Swagger UI");
				o.InjectStylesheet("/swagger-ui/custom.css");
				o.InjectJavascript("/swagger-ui/custom.js");

			});

			app.UseSwagger();

			app.UseRouting();

			app.UseAuthorization();

			app.UseStaticFiles();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapHub<DeckHub>("/deckHub");
			});
		}
	}
}
