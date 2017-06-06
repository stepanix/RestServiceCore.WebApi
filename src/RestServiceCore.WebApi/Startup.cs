using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestServiceCore.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using RestServiceCore.Service.Services.Tags;
using RestServiceCore.Domain.Repositories;
using RestServiceCore.EntityFrameWork.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using RestServiceCore.Service.Services.Positions;
using RestServiceCore.Service.Services;

namespace RestServiceCore.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = Configuration["AppSettings:DbConnectionString"];
            DataContext.ConnectionString = Configuration.GetConnectionString(sqlConnectionString);
            
            services.AddDbContext<DataContext>(options => options.UseSqlServer(sqlConnectionString));

            // Add framework services.
            services.AddAuthentication(options => options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme);
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            services.AddCors();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactService, ContactService>();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "Cookies",
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });
            app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            {
                ClientId = "CLIENT_ID_GOES_HERE",
                ClientSecret = "CLIENT_SECRET_GOES_HERE",
                Authority = "https://accounts.google.com",
                ResponseType = OpenIdConnectResponseType.Code,
                GetClaimsFromUserInfoEndpoint = true,
                SaveTokens = true,
                Events = new OpenIdConnectEvents()
                {
                    OnRedirectToIdentityProvider = (context) =>
                    {
                        if (context.Request.Path != "/account/external")
                        {
                            context.Response.Redirect("/account/login");
                            context.HandleResponse();
                        }

                        return Task.FromResult(0);
                    }
                }
            });
            app.UseMvc();
        }
    }
}
