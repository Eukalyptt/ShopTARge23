using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Core.Dto;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Models.Email;

namespace ShopTARge23.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailServices _emailServices;

        public EmailController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new EmailIndexViewModel());
        }

        [HttpPost]
        public IActionResult Send(EmailIndexViewModel viewModel)
        {
            try
            {
                var emailDto = new EmailDto
                {
                    To = viewModel.To,
                    Subject = viewModel.Subject,
                    Body = viewModel.Body,
                    Attachments = viewModel.Attachments
                };

                _emailServices.SendEmail(emailDto);
                ViewBag.Message = "Email sent successfully!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error sending message: {ex.Message}";
            }

            return View("Index", viewModel);
        }
    }
}
