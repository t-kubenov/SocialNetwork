using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Areas.Identity.Data;
using SocialNetwork.Data;
using SocialNetwork.Models;
using System;
namespace SocialNetwork.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private readonly SocialNetworkContext _context;
        private readonly UserManager<SocialNetworkUser> _userManager;


        public UserController(SocialNetworkContext context, UserManager<SocialNetworkUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        
        public IActionResult Index(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;

            if (user == null)
            {
                user = _userManager.FindByIdAsync(_userManager.GetUserId(User)).Result;
            }
            //var user = _context.Users.Where(x => x.UserName == User.Identity.Name);
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
            // for some reason, passing the data as type friendsDB does not include the requester, so I had to filter the data with the select query (and that works for some reason).

            return View(requestList);
        }


        public IActionResult FriendsList(string id) {
            if (id == null)
            {
                id = _userManager.GetUserId(User);
            }

            var user = _userManager.FindByIdAsync(id).Result;
            var friendsList = _context.Friendships.Where(x => x.StatusCode == 1 && x.Requester == user).Select(x => x.Addressee).ToList();
            var temp = _context.Friendships.Where(x => x.StatusCode == 1 && x.Addressee == user).Select(x => x.Requester).ToList();

            friendsList.AddRange(temp); 
            // since we don't know whether the user sent the request or it was sent to him, we concatenate two lists with either cases.

            return View(friendsList);
        }


        public void AcceptFriendRequest(int requestId)
        {
            var addressee = _context.Friendships.Where(x => x.Id == requestId).Select(x => x.Addressee).SingleOrDefault();
            if (addressee != null && addressee == _userManager.FindByIdAsync(_userManager.GetUserId(User)).Result) // make sure the appropriate user is accepting the request
            {
                _context.Friendships.Where(x => x.Id == requestId).Single().StatusCode = 1;
                _context.SaveChanges();
            }
        }


        public void RemoveFromFriends(int requestId)
        {
            var thisUser = _userManager.FindByIdAsync(_userManager.GetUserId(User)).Result;
            var query = _context.Friendships.Where(x => x.Id == requestId);
            var contract = query.Select(x => new { x.Addressee, x.Requester }).SingleOrDefault();

            if (contract != null && (contract.Requester == thisUser || contract.Addressee == thisUser)) // make sure the appropriate user is removing another user from friends
            {
                _context.Friendships.Remove(query.Single());
                _context.SaveChanges();
            }
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
