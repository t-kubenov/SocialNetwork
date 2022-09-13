using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Areas.Identity.Data;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Controllers
{
    public class CommunityController : Controller
    {
        private readonly SocialNetworkContext _context;
        private readonly UserManager<SocialNetworkUser> _userManager;

        public CommunityController(SocialNetworkContext context, UserManager<SocialNetworkUser> userManager) {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Index(int id)
        {
            var community = _context.Communities.Where(x => x.Id == id).SingleOrDefault();

            if (community == null)
            {
                return RedirectToAction("Index", "User"); // if the community id does not exist, redirect to the user's own page;
            }

            return View(community);
        }

        [Authorize]
        public IActionResult CreateCommunity(string communityName) {
            //public int Id { get; set; }
            //public SocialNetworkUser? Owner { get; set; }
            //public DateTime DateCreated { get; set; }
            //public string Name { get; set; }
            //public string? AvatarPath { get; set; }

            var user = _userManager.FindByIdAsync(_userManager.GetUserId(User)).Result;

            CommunityDB communityDB = new()
            {
                Owner = user,
                Name = communityName,
            };

            _context.Communities.Add(communityDB);
            _context.SaveChanges();

            return RedirectToAction("Index", "Community");
        }


        public void JoinCommunity()
        {

        }

        public void LeaveCommunity()
        {

        }
    }
}
