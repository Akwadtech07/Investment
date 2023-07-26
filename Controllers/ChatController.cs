using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using New_folder.Models.Dtos;
using New_folder.Services.Interfaces;
using System.Security.Claims;

namespace New_folder.Controllers
{
    public class ChatController : Controller
    {
        private readonly IUserService _userService;
        private readonly IChatService _chatService;
        public ChatController(IUserService userService, IChatService chatService)
        {
            _userService = userService;
            _chatService = chatService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Contact()
        {
            var senderId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var bring = await _userService.GetAll(senderId);
            return View(bring.Data);
        }
        [Authorize(Roles = "Broker,Investor")]
        [HttpPost]
        public async Task<IActionResult> CreateChat(CreateChatRequestModel model, string id)
        {
            var senderId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var chat = await _chatService.CreateChat(model, senderId, id);
            if (chat.Success == true)
            {
                TempData["success"] = "Registration Sucessful";
                return RedirectToAction("CreateChat", "Chat");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateChat(string id)
        {
            var senderId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.Message = senderId;
            var contact = await _chatService.Get(senderId, id);
            if (contact.Success == true)
            {
                return View(contact.Data);
            }
            return RedirectToAction("Contact");
        }
    }  
}
