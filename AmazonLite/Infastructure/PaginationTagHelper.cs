using AmazonLite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AmazonLite.Infastructure;

[HtmlTargetElement("div", Attributes = "page-model")]
public class PaginationTagHelper : TagHelper
{
    private IUrlHelperFactory UrlHelperFactory;

    public PaginationTagHelper(IUrlHelperFactory temp)
    {
        UrlHelperFactory = temp;
    }

    [ViewContext] [HtmlAttributeNotBound] public ViewContext? ViewContext { get; set; }
    public string? PageAction { get; set; }
    public PaginationInfo PageModel { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (ViewContext != null && PageAction != null)
        {
            IUrlHelper urlHelper = UrlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });
                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}