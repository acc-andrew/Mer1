
namespace Mer1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // 1.
            // API CORS
            builder.Services.AddCors(op =>
                op.AddPolicy("WebSitePolicy", builder =>
                {
                    builder.WithOrigins
                            // frontend launches address
                            ("http://localhost:5173", "http://localhost:3000")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                })
            );



            var app = builder.Build();

            // 2.
            app.UseCors("WebSitePolicy");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
