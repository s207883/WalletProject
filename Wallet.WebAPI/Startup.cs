using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using Wallet.BLL;
using Wallet.BLL.Implementations;
using Wallet.BLL.Interfaces;
using Wallet.Core.AutomapperConfig;
using Wallet.DAL;
using Wallet.Services.CurrencyService;

namespace Wallet.WebAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddDbContext<ApplicationContext>
			(
				//TODO: Move to settings.json
				options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WebAPI_DB;Integrated Security=true;"
			));

			services.AddSingleton<ICurrencyService, CurrencyService>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IBankAccountRepository, BankAccountRepository>();
			services.AddScoped<IWalletRepository, WalletRepository>();

			services.AddScoped<RepoManager>();

			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new BankAccountProfile());
				mc.AddProfile(new UserWalletProfile());
				mc.AddProfile(new CurrencyProfile());
				mc.AddProfile(new UserProfile());
			});

			var mapper = mappingConfig.CreateMapper();

			services.AddSingleton(mapper);

			services.AddSwaggerGen(sg =>
			{
				sg.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Version = "v1",
					Title = "Web API",
				});
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				sg.IncludeXmlComments(xmlPath);
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
