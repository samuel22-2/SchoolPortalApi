using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SchoolPortalApi.Models;

public class Program
{
    public static void Main(string[] args)

    {

        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                             policy =>
                             {
                                 policy.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                             });
        });

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddDistributedMemoryCache();

        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddDbContext<TestContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));



        // Learn more about configuring Swagger/Open
        // API at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

            // Define the security scheme (JWT)
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "JWT Authorization header using the Bearer scheme",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            };
            // Add the security scheme to the document
            c.AddSecurityDefinition("JWT", securityScheme);

            // Configure the global security requirement to use the security scheme defined above
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "JWT"
                            }
                        },
                        new string[] { }
                    }
                });
        });

        





        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(x =>
        {
            x.AllowAnyOrigin();
            x.WithOrigins("https://localhost:7095");
            x.AllowAnyMethod();
            x.AllowAnyHeader();
        });

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();



        app.MapControllers();
        app.UseSession();

        app.Run();
    }
}
