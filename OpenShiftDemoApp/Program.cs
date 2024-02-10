using OpenShiftDemoApp.Extensions;
using OpenShiftDemoApp.Services;

namespace OpenShiftDemoApp;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services
            .AddSingleton<AppInfoProvider>()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.MapMetaEndpoints();
        app.Run();
    }
}