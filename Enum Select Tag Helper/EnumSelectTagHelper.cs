[HtmlTargetElement("enum-select", TagStructure = TagStructure.NormalOrSelfClosing)]
public class EnumSelectTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "select";
        string selectTag = RenderSelectTag();
        output.Content.SetHtmlContent(new HtmlString(selectTag));
    }
    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "select";
        string selectTag = RenderSelectTag();
        output.Content.SetHtmlContent(new HtmlString(selectTag));
        return base.ProcessAsync(context, output);
    }
    [HtmlAttributeName("enum")]
    public Type Enum { get; set; }
    private string RenderSelectTag()
    {
        StringBuilder optionsStringBuilder = new StringBuilder();
        var enumDictionary = Functions.GetEnumList(Enum);
        foreach (var enumItem in enumDictionary)
        {
            optionsStringBuilder.Append($"<option value\"{enumItem.Key}\">{enumItem.Value}</option>");
        }
        return optionsStringBuilder.ToString();
    }
}