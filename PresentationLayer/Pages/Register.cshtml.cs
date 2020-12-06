using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.UserBLL;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PresentationLayer.Pages
{
    public class RegisterModel : PageModel
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            bool check = await userBLL.CreateNewUser(user.Username, user.Password, user.Email);
            if(check == true)
            {
                Msg = "Thanh cong";
                
            }
            else
            {
                Msg = "That bai";
            }
            //return RedirectToPage("./Index");
            return Page();
        }
    }
}
