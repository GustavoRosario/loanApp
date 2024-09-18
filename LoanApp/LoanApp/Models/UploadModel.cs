using Microsoft.AspNetCore.Http;

namespace LoanApp.Models
{
    public class UploadModel
    {
        public IFormFile MyFile { get; set; }
    }
}
