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
            var user = _userManager.FindByIdAsync(id).Result;
            return View(user);
        }        
        

        public IActionResult UserList()
        {
            var userList = _context.Users.ToList();
            return View(userList);
        }


        public void AddToFriends(string targetUser)
        {
            var user = _userManager.FindByIdAsync(_userManager.GetUserId(User)).Result;
            var target = _userManager.FindByIdAsync(targetUser).Result;

            if (_context.Friendships.Where(x => x.Requester == user && x.Addressee == target).SingleOrDefault() == null
                && user != target) // make sure the same friend request does not exist in the table and the user is not sending the request to himself
            {
                FriendsDB friendsDB = new()
                {
                    Requester = user,
                    Addressee = target,
                    StatusCode = 0,
                };
                _context.Friendships.Add(friendsDB);
                _context.SaveChanges();
            }

        }


        public IActionResult PendingFriendRequests()
        {
            var user = _userManager.FindByIdAsync(_userManager.GetUserId(User)).Result;
            var requestList = _context.Friendships.Where(x => x.Addressee == user && x.StatusCode == 0).Select(x => new {x.Id, x.Requester, x.DateInitiated}).ToList();
            // for some reason, passing the data as type friendsDB does not include the requester, so I had to filter the data with the select query.

            return View(requestList);
        }


        public string AcceptFriendRequest(int id)
        {
            var query = _context.Friendships.Where(x => x.Id == id).Select(x => x.Addressee).SingleOrDefault();
            if (query != null && query == _userManager.FindByIdAsync(_userManager.GetUserId(User)).Result) // make sure the appropriate user is accepting the request
            {
                _context.Friendships.Where(x => x.Id == id).Single().StatusCode = 1;
                _context.SaveChanges();
                return "based";
            }
            return "cringe";
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
        
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //public IActionResult Signup()
        //{
        //    return View();
        //}
    }
}
