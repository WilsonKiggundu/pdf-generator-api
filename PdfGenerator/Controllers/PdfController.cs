using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;

namespace PdfGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase 
    {
        [HttpGet]
        public string Index()
        {
            return "Pdf Generator";
        }

        [HttpPost]
        public ActionResult<string> Generate([FromBody] string html) 
        {
            var workStream = new MemoryStream();
            var byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            var converter = new SelectPdf.HtmlToPdf
            {
                Options =
                {
                    DisplayHeader = true,
                    DisplayFooter = true,
                    MarginLeft = 20,
                    MarginRight = 20,
                    MaxPageLoadTime = 200,
                    EmbedFonts = true
                }
            };

            var filename = $"{Guid.NewGuid()}.pdf";
            var doc = converter.ConvertHtmlString(html);

            doc.Save(filename);
            doc.Close();

            return filename;
        }

    }
}
