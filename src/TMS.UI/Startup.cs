using System;
using System.Net.Http;
using System.Runtime;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TMS.UI.Pages.Games;
using TMS.UI.Pages.Players;
using TMS.UI.Pages.Teams;
using TMS.UI.Services;
using TMS.UI.Shared.NavMenu;

namespace TMS.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor()
                .AddCircuitOptions(options => { options.DetailedErrors = true; });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILocationService, LocationService>();

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.Authority = "http://localhost:5000";
                        options.ClientId = "tmsui";
                        options.ClientSecret = "108B7B4F-BEFC-4DD2-82E1-7F025F0F75D0";
                        options.ResponseType = "code id_token";
                        options.Scope.Add("openid");
                        options.Scope.Add("profile");
                        options.Scope.Add("email");
                        options.Scope.Add("tmsapi");
                        options.Scope.Add("teamrole");
                        options.ClaimActions.MapUniqueJsonKey("teamrole", "teamrole");
                        options.SaveTokens = true;
                        options.GetClaimsFromUserInfoEndpoint = true;
                        options.RequireHttpsMetadata = false;
                    });
            
            services.AddAuthorization(authorizationOptions =>
            {
                authorizationOptions.AddPolicy(
                    Policies.IsStaff,
                    Policies.IsStaffPolicy());
            });

            var apiUri = new Uri("https://localhost:7001");
            void RegisterTypedClient<TClient, TImplementation>(Uri apiBaseUrl) where TClient : class
                where TImplementation : class, TClient
            {
                services.AddHttpClient<TClient, TImplementation>(client =>
                {
                    client.BaseAddress = apiBaseUrl;
                }).ConfigurePrimaryHttpMessageHandler(() => {
                    var handler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                    };
                    return handler;
                });
            }
            
            RegisterTypedClient<IMenuService, MenuService>(apiUri);
            RegisterTypedClient<ITeamsService, TeamsService>(apiUri);
            RegisterTypedClient<IPlayersService, PlayersService>(apiUri);
            RegisterTypedClient<IGamesService, GamesService>(apiUri);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthorization();
            app.UseAuthentication();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}