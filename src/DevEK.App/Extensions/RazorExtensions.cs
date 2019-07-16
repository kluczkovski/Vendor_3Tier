using System;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DevEK.App.Extensions
{
    public static class RazorExtensions
    {
        public static string FormatDocumentId(this RazorPage page, int vendorType, string document)
        {
            return vendorType == 1 ? Convert.ToUInt64(document).ToString(@"000\.000\.000\-00")
                                   : Convert.ToUInt64(document).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
