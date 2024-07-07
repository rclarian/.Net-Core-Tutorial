using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers.Controllers
{
    public class FileController : Controller
    {
        [Route("File/Download-file")]
        public VirtualFileResult Index()
        {
            return File("/Samples/Sample.pdf", "application/pdf");
        }
    }
}
