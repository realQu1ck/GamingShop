#pragma checksum "C:\Users\nima4\OneDrive\Desktop\OGS\GamingShop\GamingShop\Views\Show\ShowAllProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f8d89ca7e8e2521c8128030f2b2eb2761dabc63"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Show_ShowAllProducts), @"mvc.1.0.view", @"/Views/Show/ShowAllProducts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Show/ShowAllProducts.cshtml", typeof(AspNetCore.Views_Show_ShowAllProducts))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\nima4\OneDrive\Desktop\OGS\GamingShop\GamingShop\Views\_ViewImports.cshtml"
using GamingShop;

#line default
#line hidden
#line 2 "C:\Users\nima4\OneDrive\Desktop\OGS\GamingShop\GamingShop\Views\_ViewImports.cshtml"
using GamingShop.Models;

#line default
#line hidden
#line 3 "C:\Users\nima4\OneDrive\Desktop\OGS\GamingShop\GamingShop\Views\_ViewImports.cshtml"
using GamingShop.ViewModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f8d89ca7e8e2521c8128030f2b2eb2761dabc63", @"/Views/Show/ShowAllProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8758681afa7bf21b8a74fed78fc0974b07b809d3", @"/Views/_ViewImports.cshtml")]
    public class Views_Show_ShowAllProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TblProduct>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\nima4\OneDrive\Desktop\OGS\GamingShop\GamingShop\Views\Show\ShowAllProducts.cshtml"
  
    ViewData["Title"] = "ShowAllProducts";

#line default
#line hidden
            BeginContext(53, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(80, 30, true);
            WriteLiteral("    <div class=\"form-group\">\r\n");
            EndContext();
#line 8 "C:\Users\nima4\OneDrive\Desktop\OGS\GamingShop\GamingShop\Views\Show\ShowAllProducts.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(159, 32, true);
            WriteLiteral("            <div class=\"product\"");
            EndContext();
            BeginWriteAttribute("productid", " productid=\"", 191, "\"", 211, 1);
#line 10 "C:\Users\nima4\OneDrive\Desktop\OGS\GamingShop\GamingShop\Views\Show\ShowAllProducts.cshtml"
WriteAttributeValue("", 203, item.Id, 203, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(212, 114, true);
            WriteLiteral(" style=\"width:250px; margin:5px\">\r\n                <div style=\"width:100%;height:200px\">\r\n                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 326, "\"", 422, 1);
#line 12 "C:\Users\nima4\OneDrive\Desktop\OGS\GamingShop\GamingShop\Views\Show\ShowAllProducts.cshtml"
WriteAttributeValue("", 332, $"data:image/jpg;base64,{Convert.ToBase64String(item.TblProductImgs.First().ImgThumb)}", 332, 90, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(423, 52, true);
            WriteLiteral(">\r\n                    <div class=\"product-label\">\r\n");
            EndContext();
            BeginContext(589, 144, true);
            WriteLiteral("                    </div>\r\n                </div>\r\n                <div class=\"product-body\">\r\n                    <p class=\"product-category\">");
            EndContext();
            BeginContext(734, 21, false);
#line 19 "C:\Users\nima4\OneDrive\Desktop\OGS\GamingShop\GamingShop\Views\Show\ShowAllProducts.cshtml"
                                           Write(item.TblCategory.Name);

#line default
#line hidden
            EndContext();
            BeginContext(755, 63, true);
            WriteLiteral("</p>\r\n                    <h3 class=\"product-name\"><a href=\"#\">");
            EndContext();
            BeginContext(819, 16, false);
#line 20 "C:\Users\nima4\OneDrive\Desktop\OGS\GamingShop\GamingShop\Views\Show\ShowAllProducts.cshtml"
                                                    Write(item.TblAll.Name);

#line default
#line hidden
            EndContext();
            BeginContext(835, 57, true);
            WriteLiteral("</a></h3>\r\n                    <h4 class=\"product-price\">");
            EndContext();
            BeginContext(893, 10, false);
#line 21 "C:\Users\nima4\OneDrive\Desktop\OGS\GamingShop\GamingShop\Views\Show\ShowAllProducts.cshtml"
                                         Write(item.Price);

#line default
#line hidden
            EndContext();
            BeginContext(903, 32, true);
            WriteLiteral(" <del class=\"product-old-price\">");
            EndContext();
            BeginContext(936, 10, false);
#line 21 "C:\Users\nima4\OneDrive\Desktop\OGS\GamingShop\GamingShop\Views\Show\ShowAllProducts.cshtml"
                                                                                    Write(item.Price);

#line default
#line hidden
            EndContext();
            BeginContext(946, 484, true);
            WriteLiteral(@"</del></h4>
                    <div class=""product-rating"">
                        <i class=""fa fa-star""></i>
                        <i class=""fa fa-star""></i>
                        <i class=""fa fa-star""></i>
                        <i class=""fa fa-star""></i>
                        <i class=""fa fa-star""></i>
                    </div>
                </div>
                <div class=""add-to-cart"">
                    <button class=""add-to-cart-btn"" id=""addtocart""");
            EndContext();
            BeginWriteAttribute("cartid", " cartid=\"", 1430, "\"", 1447, 1);
#line 31 "C:\Users\nima4\OneDrive\Desktop\OGS\GamingShop\GamingShop\Views\Show\ShowAllProducts.cshtml"
WriteAttributeValue("", 1439, item.Id, 1439, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1448, 108, true);
            WriteLiteral("><i class=\"fa fa-shopping-cart\"></i>اضافه به سبد خرید</button>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 34 "C:\Users\nima4\OneDrive\Desktop\OGS\GamingShop\GamingShop\Views\Show\ShowAllProducts.cshtml"
        }

#line default
#line hidden
            BeginContext(1567, 896, true);
            WriteLiteral(@"
    </div>
<script>
    $(function () {
        $(addtocart).click(function () {
            var cartid = $(this).attr('cartid');
            $.post('/PurchaseCard/AddToCart', { cartid: cartid }, function (value) {
                if (value === true) {
                    alert(""Succuss"");
                }
            })
        })
    })
    $(addtowish).click(function () {
        var cartid = $(this).attr('cartid');
        $.post('/WishList/AddToCart', { cartid: cartid }, function (value) {
            if (value === true) {
                alert(""Succuss"");
            }
        })
    })
    $(quickview).click(function () {
        var cartid = $(this).attr('cartid');
        $.post('/Show/CheckQuickView', { cartid: cartid }, function (value) {
            if (value === true) {
                alert(""S"");
            }
        })
    })
</script>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TblProduct>> Html { get; private set; }
    }
}
#pragma warning restore 1591