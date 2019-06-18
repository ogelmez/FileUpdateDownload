using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadDownload.Models
{
    public class FileUploadDownloadViewModel
    {
        public IFormFile File { get; set; }
        public long size { get; set; }
        public int width { get; set; }
        public  int height{ get; set; }
        public string extension { get; set; }
        public string destination { get; set; }
    }
}
