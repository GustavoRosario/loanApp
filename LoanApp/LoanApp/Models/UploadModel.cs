using Microsoft.AspNetCore.Http;

namespace LoanApp.Models
{
    public class UploadModel
    {
        IFormFile MyFile { get; set; }
    }
}
