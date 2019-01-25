    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationFormats.Clear();
                options.ViewLocationFormats.Add("/Emails/Views/{0}" + RazorViewEngine.ViewExtension);
            });
        }
    }