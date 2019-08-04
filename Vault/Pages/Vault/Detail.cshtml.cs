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
    public class DetailModel : PageModel
    {
        private readonly IPasswordData passwordData;

        public Password Password{ get; set; }

        public DetailModel(IPasswordData passwordData)
        {
            this.passwordData = passwordData;
        }

        public IActionResult OnGet(int passwordId)
        {
            Password = passwordData.GetPasswordById(passwordId);

            if(Password == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}

