#pragma checksum "C:\Users\Administrator\Documents\GitHub\Codingdojo_Assigments_C_Sharp\ORMs\BeltTest\Views\Home\Display.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "150ae3ba6805188283670295aa93f6b7f1ca4a0d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Display), @"mvc.1.0.view", @"/Views/Home/Display.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Display.cshtml", typeof(AspNetCore.Views_Home_Display))]
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
#line 1 "C:\Users\Administrator\Documents\GitHub\Codingdojo_Assigments_C_Sharp\ORMs\BeltTest\Views\_ViewImports.cshtml"
using BeltTest;

#line default
#line hidden
#line 2 "C:\Users\Administrator\Documents\GitHub\Codingdojo_Assigments_C_Sharp\ORMs\BeltTest\Views\_ViewImports.cshtml"
using BeltTest.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"150ae3ba6805188283670295aa93f6b7f1ca4a0d", @"/Views/Home/Display.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ca22adfd586e6c512725952d726678e031c7cdd", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Display : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 15, true);
            WriteLiteral("<div>\r\n    <h1>");
            EndContext();
            BeginContext(16, 13, false);
#line 2 "C:\Users\Administrator\Documents\GitHub\Codingdojo_Assigments_C_Sharp\ORMs\BeltTest\Views\Home\Display.cshtml"
   Write(Model.Wedder1);

#line default
#line hidden
            EndContext();
            BeginContext(29, 5, true);
            WriteLiteral(" and ");
            EndContext();
            BeginContext(35, 13, false);
#line 2 "C:\Users\Administrator\Documents\GitHub\Codingdojo_Assigments_C_Sharp\ORMs\BeltTest\Views\Home\Display.cshtml"
                      Write(Model.Wedder2);

#line default
#line hidden
            EndContext();
            BeginContext(48, 105, true);
            WriteLiteral("\'s Wedding</h1>\r\n    <a href=\"/Dashboard\">Dashboard</a>\r\n    <a href=\"/logout\">Logout</a>\r\n    <h2>Date: ");
            EndContext();
            BeginContext(154, 10, false);
#line 5 "C:\Users\Administrator\Documents\GitHub\Codingdojo_Assigments_C_Sharp\ORMs\BeltTest\Views\Home\Display.cshtml"
         Write(Model.Date);

#line default
#line hidden
            EndContext();
            BeginContext(164, 38, true);
            WriteLiteral("</h2>\r\n    <br>\r\n    <h2>Guests</h2>\r\n");
            EndContext();
#line 8 "C:\Users\Administrator\Documents\GitHub\Codingdojo_Assigments_C_Sharp\ORMs\BeltTest\Views\Home\Display.cshtml"
     foreach(var Guest in Model.GuestsOfWedding){

#line default
#line hidden
            BeginContext(253, 11, true);
            WriteLiteral("        <p>");
            EndContext();
            BeginContext(265, 20, false);
#line 9 "C:\Users\Administrator\Documents\GitHub\Codingdojo_Assigments_C_Sharp\ORMs\BeltTest\Views\Home\Display.cshtml"
      Write(Guest.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(285, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(287, 19, false);
#line 9 "C:\Users\Administrator\Documents\GitHub\Codingdojo_Assigments_C_Sharp\ORMs\BeltTest\Views\Home\Display.cshtml"
                            Write(Guest.User.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(306, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 10 "C:\Users\Administrator\Documents\GitHub\Codingdojo_Assigments_C_Sharp\ORMs\BeltTest\Views\Home\Display.cshtml"
    }

#line default
#line hidden
            BeginContext(319, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
