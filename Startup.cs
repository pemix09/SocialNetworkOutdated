using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using SocialNetwork.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using SocialNetwork.Services;

namespace SocialNetwork
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
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddSingleton<IFileProvider>(
           new PhysicalFileProvider(
               Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddControllers();
            services.AddRazorPages()
             .AddMvcOptions(options =>
             {
                 options.Filters.Add(new CustomPageFilter(Configuration));
             });
            services.Add(new ServiceDescriptor(typeof(IBase64), new Base64Converter()));

            services.AddDbContext<SocialNetworkContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SocialNetworkContext")));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddDbContext<SocialNetworkContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SocialNetworkContext")));
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
            services.Configure<PasswordHasherOptions>(options =>
    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2);
            services.AddIdentity<AppUser, IdentityRole>()//.AddRoles<IdentityRole> role chyba ju¿ s¹?
                    .AddEntityFrameworkStores<SocialNetworkContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                     policy => policy.RequireRole("Admin, SuperAdmin"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            CreateRoles(serviceProvider, Configuration);
        }
        private void CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            //u¿ywanie Wait() boli mnie wewnêtrznie, bo to takie wymuszenie synchronicznego dzia³ania
            //asynchronicznych metod, no ale nie mam pojêcia jak dzia³aæ inaczej
            //by wymusiæ dzia³anie tego trzeba usun¹æ dan¹ rolê z aspnetroles, inaczej po prostu przeskoczy
            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var _config = Configuration;

            Task<bool> x = _roleManager.RoleExistsAsync("MasterAdmin");
            x.Wait();
            if (!x.Result)
            {
                   
                var role = new IdentityRole();
                role.Name = "MasterAdmin";
                var r = _roleManager.CreateAsync(role);
                r.Wait();
                                 

                var user = new AppUser();
                user.UserName = _config.GetValue<string>("MasterAdminInformation:Name");
                user.Email = _config.GetValue<string>("MasterAdminInformation:Email");
                string userPWD = _config.GetValue<string>("MasterAdminInformation:Password");
                Task<AppUser> u1 = _userManager.FindByEmailAsync(user.Email);
                u1.Wait();
                if (u1.Result == null)
                {
                    Task<IdentityResult> chkUser = _userManager.CreateAsync(user, userPWD);
                    chkUser.Wait();

                    if (chkUser.Result.Succeeded)
                    {
                        var v = _userManager.AddToRoleAsync(user, "MasterAdmin");
                        v.Wait();
                    }
                }
            }


            x =  _roleManager.RoleExistsAsync("Admin");
            x.Wait();
            if (!x.Result)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                var r1 = _roleManager.CreateAsync(role);
                r1.Wait();


                var user = new AppUser();
                user.UserName = _config.GetValue<string>("AdminInformation:Name1");
                user.Email = _config.GetValue<string>("AdminInformation:Email1");
                string userPWD = _config.GetValue<string>("AdminInformation:Password1");

                Task<AppUser> u1 = _userManager.FindByEmailAsync(user.Email);
                u1.Wait();
                if (u1.Result == null)
                {
                    Task<IdentityResult> chkUser = _userManager.CreateAsync(user, userPWD);
                    chkUser.Wait();
                    if (chkUser.Result.Succeeded)
                    {
                        var v = _userManager.AddToRoleAsync(user, "Admin");
                        v.Wait();
                    }
                }
                var user2 = new AppUser();
                user2.UserName = _config.GetValue<string>("AdminInformation:Name2");
                user2.Email = _config.GetValue<string>("AdminInformation:Email2");
                string userPWD2 = _config.GetValue<string>("AdminInformation:Password2");
                Task<AppUser> u2 = _userManager.FindByEmailAsync(user2.Email);
                u2.Wait();
                if (u2.Result == null)
                {
                    Task<IdentityResult> chkUser = _userManager.CreateAsync(user2, userPWD);
                    chkUser.Wait();
                    if (chkUser.Result.Succeeded)
                    {
                        var v = _userManager.AddToRoleAsync(user2, "Admin");
                        v.Wait();
                    }
                }
            }
    
            x = _roleManager.RoleExistsAsync("User");
            x.Wait();
            if (!x.Result)
            {
                var role = new IdentityRole();
                role.Name = "User";
                 var c = _roleManager.CreateAsync(role);
                c.Wait();
            }
        }
    }
}
