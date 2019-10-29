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
    public class DeleteModel : PageModel
    {
        private readonly IPasswordData passwordData;
        public Password Password { get; set; }

        public DeleteModel(IPasswordData passwordData)
        {
            this.passwordData = passwordData;
        }


        public IActionResult OnGet(int passwordId)
        {
            Password = passwordData.GetPasswordById(passwordId);

            if (Password == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int passwordId)
        {
            var Password = passwordData.GetPasswordById(passwordId);

            if(passwordData != null)
            {
                passwordData.Delete(passwordId);
                passwordData.Commit();
            }

            TempData["Message"] = $"{Password.Name} has been deleted!";
            return RedirectToPage("./List");
        }
    }
}