public class NotificationService : INotificationService
{
    private readonly IRazorViewEngine razorViewEngine;
    private readonly ITempDataProvider tempDataProvider;
    private readonly IServiceProvider serviceProvider;

    public NotificationService(IRazorViewEngine razorViewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider)
    {
        this.razorViewEngine = razorViewEngine;
        this.tempDataProvider = tempDataProvider;
        this.serviceProvider = serviceProvider;
    }

    private async Task<string> RenderToStringAsync(string viewName, AbstractEmailModel model)
    {
        var httpContext = new DefaultHttpContext { RequestServices = this.serviceProvider };
        var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

        using (var sw = new StringWriter())
        {
            var viewResult = this.razorViewEngine.FindView(actionContext, viewName, false);

            if (viewResult.View == null)
            {
                throw new ArgumentNullException($"{viewName} does not match any available view");
            }

            var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };

            var viewContext = new ViewContext(
                actionContext,
                viewResult.View,
                viewDictionary,
                new TempDataDictionary(actionContext.HttpContext, this.tempDataProvider),
                sw,
                new HtmlHelperOptions()
            );

            await viewResult.View.RenderAsync(viewContext);
            return sw.ToString();
        }
    }
}