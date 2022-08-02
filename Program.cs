using ContactSim.Interfaces.ILiteDbSetup;
using ContactSim.Interfaces.IServices;
using ContactSim.LiteDbSetup;
using ContactSim.Services;

namespace ContactSim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<ILiteDbContext, LiteDbContext>();
            builder.Services.Configure<LiteDbOptions>(
               builder.Configuration.GetSection(LiteDbOptions.DatabaseOptions));
            
            builder.Services.AddTransient<IContactService, ContactService>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}