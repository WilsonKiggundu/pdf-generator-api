using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PdfGenerator.Controllers
{
    [Route("file")]
    public class FileController : Controller
    {
        [Route("")]
        public IActionResult Index(string filename)
        {
            var pdfByteArray = System.IO.File.ReadAllBytes(filename);
            return File(pdfByteArray, MediaTypeNames.Application.Pdf, filename);
        }
    }
}