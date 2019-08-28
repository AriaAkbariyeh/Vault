using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vault.Core;
using Vault.Data;

namespace Vault.Pages.Vault
{
    public class EditModel : PageModel
    {
        private readonly IPasswordData passwordData;

        [BindProperty]
        public Password Password { get; set; }

        public EditModel(IPasswordData passwordData)
        {
            this.passwordData = passwordData;
        }

        public IActionResult OnGet(int? passwordId)
        {

            if (passwordId.HasValue)
            {
                Password = passwordData.GetPasswordById(passwordId.Value);
            }else
            {
                Password = new Password();
            }

            if (Password == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }


        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(Password.Id > 0)
            {
                Password = passwordData.Update(Password);
                
            } else
            {
                passwordData.Add(Password);
            }

            passwordData.Commit();
            return RedirectToPage("./List");

        }
    }
}