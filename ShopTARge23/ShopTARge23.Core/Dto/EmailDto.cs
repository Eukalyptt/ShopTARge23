using Microsoft.AspNetCore.Http;

namespace ShopTARge23.Core.Dto
{
    public class EmailDto
    {
        public string To { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Body { get; set; } = "";
        public List<IFormFile> Attachments {  get; set; }
    }
}
