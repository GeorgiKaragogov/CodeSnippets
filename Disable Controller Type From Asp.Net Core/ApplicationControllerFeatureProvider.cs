public class ApplicationControllerFeatureProvider : ControllerFeatureProvider
{
    protected override bool IsController(TypeInfo typeInfo)
    {
        var isCustomController = !typeInfo.IsAbstract && typeof(IApplicationController).IsAssignableFrom(typeInfo);
        if (isCustomController)
        {
            return false;
        }
        return base.IsController(typeInfo);
    }
}