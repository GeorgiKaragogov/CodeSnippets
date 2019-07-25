public static class FeatureProvidersExtensions
{
    public static IList<IApplicationFeatureProvider> DisableApplicationControllers(this IList<IApplicationFeatureProvider> featureProviders, bool disableApplicationControllers)
    {
        if (disableApplicationControllers)
        {
            var currentControllerFeatureProviders = featureProviders.Where(x => x.GetType() == typeof(ControllerFeatureProvider)).ToList();
            foreach (var featureProvider in currentControllerFeatureProviders)
            {
                featureProviders.Remove(featureProvider);
            }
            featureProviders.Add(new ApplicationControllerFeatureProvider());
        }
        return featureProviders;
    }
}