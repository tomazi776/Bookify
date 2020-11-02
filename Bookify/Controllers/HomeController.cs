using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookify.Models;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace Bookify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserProcessor _userProcessor;
        private readonly IBookmarkProcessor _bookmarkProcessor;

        public HomeController(ILogger<HomeController> logger, IUserProcessor userProcessor, IBookmarkProcessor bookmarkProcessor)
        {
            _logger = logger;
            _userProcessor = userProcessor;
            _bookmarkProcessor = bookmarkProcessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewUserBookmarks()
        {
            return View();
        }

        //[HttpGet("{userId}")]
        [Route("Home/ViewUserBookmarks/{userId}")]
        public IActionResult ViewUserBookmarks(int userId)
        {
            List<BookmarkModel> bookmarks = null;
            if (ModelState.IsValid)
            {
                bookmarks = _bookmarkProcessor.GetAllBookmarks(userId);
            }
            return View(bookmarks);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        //TODO: Add redirect to after signup page
        [HttpPost]
        public IActionResult SignUp(Models.UserModel user)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = _userProcessor.CreateUser(user.Id, user.FirstName, user.LastName, user.EmailAddress);
                //_logger.LogInformation("Record created - rows affected: ", recordsCreated);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
