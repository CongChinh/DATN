using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.UserBLL;
using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PresentationLayer.Pages
{
    public class LoginModel : PageModel
    {
        private UserBLL userBLL = new UserBLL();
        public string Msg { get; set; }

        [BindProperty]
        public User user { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            bool checkLogin = await userBLL.Login(user.Email);
            if(checkLogin == true)
            {
                HttpContext.Session.SetString("email", user.Email);
            }
            return RedirectToPage("/Index");
        }
    }
}
