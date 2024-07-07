using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers.Controllers
{
    public class FileController : Controller
    {
        [Route("File/Download-file")]
        public IActionResult FileDownload1()
        {
            return File("/Samples/Sample.pdf", "application/pdf");
        }

        [Route("File/Download-file2")]
        public IActionResult FileDownload2()
        {
            if (!System.IO.File.Exists("E:\\Project\\Tutorial2023\\.Net Core Project\\SampleFile\\Sample.pdf"))
            {
                return Content("File you specified is not found!", "text/plain");
            }
            return PhysicalFile("E:\\Project\\Tutorial2023\\.Net Core Project\\SampleFile\\Sample.pdf", "application/pdf");
        }

        [Route("File/Download-file3")]
        public IActionResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"E:\\Project\\Tutorial2023\\.Net Core Project\\SampleFile\\Sample.pdf");
            return File(bytes, "application/pdf");
        }
    }
}
