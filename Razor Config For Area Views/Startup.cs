public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<RazorViewEngineOptions>(options =>
        {
            options.ViewLocationFormats.Clear();
            options.ViewLocationFormats.Add("/Views/ControllersViews/{1}/{0}.cshtml");
            options.ViewLocationFormats.Add("/Views/ControllersViews/Shared/{0}.cshtml");

            options.AreaViewLocationFormats.Clear();
            options.AreaViewLocationFormats.Add("/Views/AreasViews/{2}/{1}/{0}.cshtml");
            options.AreaViewLocationFormats.Add("/Views/AreasViews/{2}/Shared/{0}.cshtml");
            options.AreaViewLocationFormats.Add("/Views/ControllersViews/Shared/{0}.cshtml");
        });
    }
}