using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyAmazon.Models.ViewModels;

namespace TinyAmazon.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-turn")]
    public class PaginationHelper : TagHelper
    {
        //dynamically create page links for us
        private IUrlHelperFactory uhf;
        public PaginationHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }
        //different than view context
        public PageInfo PageTurn { get; set; }
        public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i < PageTurn.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");

                tb.Attributes["class"] = "btn btn-primary btn-outline-dark";
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }

            output.Content.AppendHtml(final.InnerHtml);
        }

    }
}
