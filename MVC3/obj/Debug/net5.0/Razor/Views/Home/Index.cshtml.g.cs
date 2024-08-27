#pragma checksum "D:\RS-project\MVC3\Views\Home\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0049dac69d24ee58da16beb16512e0fa7f44d8a16d236642e3de206f16a0d563"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\RS-project\MVC3\Views\_ViewImports.cshtml"
using MVC3

#nullable disable
    ;
#nullable restore
#line 2 "D:\RS-project\MVC3\Views\_ViewImports.cshtml"
using MVC3.Areas.Access.Models

#nullable disable
    ;
#nullable restore
#line 3 "D:\RS-project\MVC3\Views\_ViewImports.cshtml"
using MVC3.ViewModels

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"0049dac69d24ee58da16beb16512e0fa7f44d8a16d236642e3de206f16a0d563", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"8dc9659427e2c713f10144719b8838a22cef8bafb1d4348e16cd674cc2b93e2c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\RS-project\MVC3\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0049dac69d24ee58da16beb16512e0fa7f44d8a16d236642e3de206f16a0d5633601", async() => {
                WriteLiteral("\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>");
                Write(
#nullable restore
#line 10 "D:\RS-project\MVC3\Views\Home\Index.cshtml"
            ViewData["Title"]

#line default
#line hidden
#nullable disable
                );
                WriteLiteral(@"</title>
    <style>
        body {
            overflow: hidden;
            /* background-color: pink; /* Pink background */
            background-color: antiquewhite; /* Pink background */
            margin: 0;
            padding: 0;
            height: 100vh;
            width: 100vw;
            position: relative;
        }

        .noise {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            pointer-events: none; /* Ensure noise layer does not interfere with mouse events */
        }

        .text-center {
            position: relative;
            z-index: 1; /* Ensure content is above the noise effect */
            text-align: center;
            padding: 20px;
        }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0049dac69d24ee58da16beb16512e0fa7f44d8a16d236642e3de206f16a0d5635772", async() => {
                WriteLiteral(@"
    <div class=""noise""></div>
    <div class=""text-center"">
        <h1 class=""display-4"">Welcome</h1>
        <p>The new HR Recruitment application for RSC.</p>
    </div>

    <!-- Load PixiJS and GSAP -->
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/pixi.js/6.5.0/pixi.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/gsap/3.9.1/gsap.min.js""></script>

    <script>
        const initNoise = () => {
            const noiseColors = [0xF4CE14, 0x379777, 0x45474B];
            const app = new PIXI.Application({
                view: document.querySelector('.noise'),
                resizeTo: window,
                antialias: true,
                backgroundAlpha: 0,
            });

            const addNoise = (x, y) => {
                const graphics = new PIXI.Graphics();
                const size = gsap.utils.random(5, 15);
                const radian = (Math.PI / 180) * gsap.utils.random(0, 360);
                const radius = gsap.utils.rand");
                WriteLiteral(@"om(0, 200);
                graphics.beginFill(noiseColors[Math.floor(gsap.utils.random(0, noiseColors.length))]);
                graphics.drawRect(0, 0, size, size);
                graphics.endFill();
                graphics.x = x || Math.cos(radian) * radius + window.innerWidth / 2;
                graphics.y = y || Math.sin(radian) * radius + window.innerHeight / 2;
                app.stage.addChild(graphics);

                gsap.fromTo(
                    graphics,
                    { alpha: 0.5 },
                    {
                        alpha: 0,
                        x: '+=' + size * Math.floor(gsap.utils.random(-5, 5)),
                        y: '+=' + size * Math.floor(gsap.utils.random(-5, 5)),
                        duration: gsap.utils.random(0.2, 1.2),
                        ease: 'steps(3)',
                        onComplete: () => {
                            app.stage.removeChild(graphics);
                        }
                    }
              ");
                WriteLiteral(@"  );
            };

            setInterval(() => addNoise(), 100);

            window.addEventListener('mousemove', (event) => {
                for (let i = 0; i < 6; i++) {
                    const radian = (Math.PI / 180) * gsap.utils.random(0, 360);
                    const radius = gsap.utils.random(0, 100);
                    const x = Math.cos(radian) * radius;
                    const y = Math.sin(radian) * radius;
                    setTimeout(() => {
                        addNoise(event.pageX + x, event.pageY + y);
                    }, gsap.utils.random(0, 600));
                }
            });
        };

        window.addEventListener('load', initNoise);
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
