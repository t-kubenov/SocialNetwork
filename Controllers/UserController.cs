using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

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
