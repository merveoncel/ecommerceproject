using Microsoft.AspNetCore.Http;

namespace ecommerceproject.ViewModels
{
    public class ImageUploadViewModel
    {
        public int MalzemeId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
