using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        FileExtensionContentTypeProvider fileExtensionContentTypeProvider;
        public FileController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            this.fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }

        [HttpGet("DownloadFile")]
        public ActionResult DownloadFile(string fileId)
        {
            string pathToFile = "download/Install-Northwind-Script.zip";
            if (!System.IO.File.Exists(pathToFile)) //اگر فایل در مسیر وجود نداشت
            {
                return NotFound();
            }
            var bytes = System.IO.File.ReadAllBytes(pathToFile);//فایل رو به صورت بایت دربیار
            return File(bytes, "text/plain", Path.GetFileName(pathToFile)); //نوع ان کد 
        }

        [HttpGet("DownloadFile2")]
        public ActionResult DownloadFile2(string fileId)
        {
            string pathToFile = "download/Install-Northwind-Script.zip";
            if (!System.IO.File.Exists(pathToFile)) //اگر فایل در مسیر وجود نداشت
            {
                return NotFound();
            }
            var bytes = System.IO.File.ReadAllBytes(pathToFile);//فایل رو به صورت بایت دربیار
            //سعی کن کانتنت تایپ رو بگیری 
            if (!fileExtensionContentTypeProvider.TryGetContentType(pathToFile , out var contentType))
            {
                //اگر کانتنت تایپ رو نتونستی تشخیص بدی بزار روی استریم 
                contentType = "application/octet-stream";
            }
           
            return File(bytes, contentType, Path.GetFileName(pathToFile)); //نوع ان کد 
        }

    }
}
