using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace DevEK.App.Extensions
{
    [HtmlTargetElement("*", Attributes = "supress-by-claim-name")]
    [HtmlTargetElement("*", Attributes = "supress-by-claim-value")]
    public class NotShowElementByClaimTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContext;
        public NotShowElementByClaimTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor;
        }

        [HtmlAttributeName("supress-by-claim-name")]
        public string IdentifyClaimName { get; set; }

        [HtmlAttributeName("supress-by-claim-value")]
        public string IdentifyClaimValue{ get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var IsItHasAcess = CustomAuthorization.CheckClaimsUser(_httpContext.HttpContext, IdentifyClaimName, IdentifyClaimValue);
            if (IsItHasAcess) return;

            output.SuppressOutput();
        }
    }


    [HtmlTargetElement("a", Attributes = "disable-by-claim-name")]
    [HtmlTargetElement("a", Attributes = "disable-by-claim-value")]
    public class DisableLinkElementByClaimTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContext;
        public DisableLinkElementByClaimTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor;
        }

        [HtmlAttributeName("disable-by-claim-name")]
        public string IdentifyClaimName { get; set; }

        [HtmlAttributeName("disable-by-claim-value")]
        public string IdentifyClaimValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var IsItHasAcess = CustomAuthorization.CheckClaimsUser(_httpContext.HttpContext, IdentifyClaimName, IdentifyClaimValue);
            if (IsItHasAcess) return;

            output.Attributes.RemoveAll("href");
            output.Attributes.Add(new TagHelperAttribute("style", "cursor: not-allowed"));
            output.Attributes.Add(new TagHelperAttribute("title", "You do not have the authorization"));
        }
    }


    [HtmlTargetElement("a", Attributes = "supress-by-action")]
    public class NotShowByActionTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContext;
        public NotShowByActionTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor;
        }

        [HtmlAttributeName("supress-by-action")]
        public string ActionName { get; set; }

     
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var action = _httpContext.HttpContext.GetRouteData().Values["action"].ToString();
            if (ActionName.Contains(action)) return;

            output.SuppressOutput();
        }
    }
}
