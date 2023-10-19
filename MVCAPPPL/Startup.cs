using MVCAPPBLL.interfaces;
using MVCAPPBLL.Repo;
using MVCAPPDAL.Context;
using MVCAPPDAL.Models;
using MVCPL.MappingProfiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCAPPPL.Settings;
using MVCAPPPL.Helpers;
using MVCPL.Helpers;


namespace EFG_MVCAPP
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
			//here we allow dependency injection | IOC container | Register Services to be Resolved
			services.AddControllersWithViews();
			services.AddDbContext<MVCAPPDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("DeafaultConnection"));
			});
			services.AddAutoMapper(E => E.AddProfile(new EmployeeProfile()));
			services.AddAutoMapper(D => D.AddProfile(new DepartmentProfile()));
			services.AddAutoMapper(U => U.AddProfile(new UserProfile()));
			services.AddAutoMapper(R => R.AddProfile(new RoleProfile()));
			//services.AddScoped<IDepartmentrepo, Departmentrepo>();
			//services.AddScoped<IEmployeerepo, Employeerepo>();
			services.AddScoped<IunitOfWork, UnitOfWork>();
            services.AddMvc()
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.AddAreaPageRoute("Admin", "/Admin/Index", "Admin");
            });

            //Auth module services Added and allow dependency injection
            //services.AddScoped<UserManager<AppUser>>();
            //services.AddScoped<SignInManager<AppUser>>();
            //services.AddScoped<RoleManager<IdentityRole>>();
            services.AddIdentity<AppUser, IdentityRole>(options =>
			{
				options.Password.RequireNonAlphanumeric = true; //Must contain   $@##$
				options.Password.RequireUppercase = true;
				options.Password.RequireLowercase = true;
				//options.Password.RequiredLength = 4;
			}
			).AddEntityFrameworkStores<MVCAPPDbContext>().AddDefaultTokenProviders();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailSettings, EmailSettings>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireRole("Admin"); // Or any other policy requirements
                });
            });

            //------------------------------Register external login---------------------------
            //services.AddAuthentication(o =>
            //{
            //    o.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
            //    o.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            //}).AddGoogle(o =>
            //{
            //    IConfiguration GoogleAuthSection = Configuration.GetSection("Authentication:Google");
            //    o.ClientId = GoogleAuthSection["ClientId"];
            //    o.ClientSecret = GoogleAuthSection["ClientSecret"];
            //});

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
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Account}/{action=Login}/{id?}");
			});
		}
	}
}
