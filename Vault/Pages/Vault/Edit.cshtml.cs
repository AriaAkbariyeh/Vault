﻿using System;
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

        public IActionResult OnGet(int passwordId)
        {

            Password = passwordData.GetPasswordById(passwordId);

            if (Password == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }


        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                Password = passwordData.Update(Password);
                passwordData.Commit();
                return RedirectToPage("./List");
            }

            return Page();
        }
    }
}