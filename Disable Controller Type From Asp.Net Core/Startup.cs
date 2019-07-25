public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc()
                .ConfigureApplicationPartManager(p =>
                {
                    //...
                    p.FeatureProviders.DisableApplicationControllers(true);
                    //...
                })
    }
}