using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Areas.Identity.Data;
using SocialNetwork.Data;
using System;
namespace SocialNetwork.Controllers
{
    public class UserController : Controller
    {
        private readonly SocialNetworkContext _context;
        private readonly UserManager<SocialNetworkUser> _userManager;

        public UserController(SocialNetworkContext context, UserManager<SocialNetworkUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [Authorize]
        public IActionResult Index(string id)
        {
            if (id == null)
            {
                id = _userManager.GetUserId(User);
            }
            //var user = _context.Users.Where(x => x.UserName == User.Identity.Name);
            var user = _context.Users.Where(x => x.Id == id).First();
            return View(user);
        }        
        
        public IActionResult UserList()
        {
            var userList = _context.Users.ToList();
            return View(userList);
        }

        //public IActionResult Login()
        //{
        //    return View();
        //}

        //public IActionResult Signup()
        //{
        //    return View();
        //}

        public void AddToFriends()
        {

        }

        public void RemoveFromFriends()
        {

        }

        public void CreateGroup()
        {

        }

        public void DeleteGroup()
        {

        }

        public void JoinGroup()
        {

        }

        public void LeaveGroup()
        {

        }
    }
}
