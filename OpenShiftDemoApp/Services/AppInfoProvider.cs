namespace OpenShiftDemoApp.Services;

public sealed class AppInfoProvider(IWebHostEnvironment environment)
{
    public Guid Id { get; } = Guid.NewGuid();

    public string Environment
        => environment.EnvironmentName;
    
    public string AppRootPath
        => environment.ContentRootPath;

}