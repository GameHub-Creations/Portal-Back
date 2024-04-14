using Microsoft.EntityFrameworkCore;
using SSO.BL;
using SSO.Configuration;
using SSO.Middlewares;
using SSO.DAL;
using SSO.Handlers;

namespace SSO;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

        Console.WriteLine(Configuration.GetConnectionString("DefaultConnection"));
        
        services.AddCors(options =>
        {
            options.AddPolicy("AllowReactApp",
                builder => builder.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        services.AddScoped<IUserDal, UserDal>();
        services.AddScoped<IUserBl, UserBl>();
        services.AddScoped<IUserHandler, UserHandler>();

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors("AllowReactApp");
        app.ConfigureDateStorage<ApplicationContext>();
        app.UseMiddleware<IncomingMessagesMiddleware>();
        app.UseMiddleware<BehaviorMiddleware>();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
            endpoints.MapControllers());
    }
}