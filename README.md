# DownloadFileFromAPI

## Step by step Download a file via Asp.net core 
. Create your download folder in project with a file in it.

. simple solution :   Create an Api controller  and inside it 

     [HttpGet("DownloadFile")]
        public ActionResult DownloadFile(string fileId)
        {
            string pathToFile = "download/Install-Northwind-Script.zip"; 
            if (!System.IO.File.Exists(pathToFile)) //اگر فایل در مسیر وجود نداشت
            {
                return NotFound(); //404 Error
            }
            var bytes = System.IO.File.ReadAllBytes(pathToFile);//فایل رو به صورت بایت دربیار
            return File(bytes, "text/plain", Path.GetFileName(pathToFile)); //نوع ان کد 
        }

. In this solution we define the type of file 


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
