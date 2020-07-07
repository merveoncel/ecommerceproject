using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerceproject.ViewModels
{
    public class ImageUploadViewModel
    {
        public int MalzemeId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
