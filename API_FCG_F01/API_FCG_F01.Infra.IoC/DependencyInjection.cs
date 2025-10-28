using System.Text;
using API_FCG_F01.Application.Interfaces;
using API_FCG_F01.Application.Mappings;
using API_FCG_F01.Application.Services;
using API_FCG_F01.Domain.Interfaces;
using API_FCG_F01.Infra.Data.Context;
using API_FCG_F01.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API_FCG_F01.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Identity Core with GUID keys
            services.AddIdentityCore<IdentityUser<Guid>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = true;
            })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager();

            // JWT Auth
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            // Authorization policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("UserPolicy", p => p.RequireRole("User"));
                options.AddPolicy("AdminPolicy", p => p.RequireRole("Admin"));
            });

            // Repositórios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IJogoRepository, JogoRepository>();
            services.AddScoped<IBibliotecaJogosRepository, BibliotecaJogosRepository>();
            services.AddScoped<IBibliotecaJogosItensRepository, BibliotecaJogosItensRepository>();

            // Application Services
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IJogoService, JogoService>();
            services.AddScoped<IBibliotecaJogosService, BibliotecaJogosService>();
            services.AddScoped<AuthService>();

            // AutoMapper
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }

        public static async Task SeedIdentityAsync(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser<Guid>>>();
            var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await ctx.Database.MigrateAsync();

            // Roles
            foreach (var roleName in new[] { "Admin", "User" })
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
                }
            }

            // Admin seed
            var adminEmail = "admin@local";
            var admin = await userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                admin = new IdentityUser<Guid>
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(admin, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
