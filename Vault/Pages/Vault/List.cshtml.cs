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
    public class ListModel : PageModel
    {
        private readonly IPasswordData passwordData;
        public IEnumerable<Password> passwords { get; set; }

        public ListModel(IPasswordData passwordData)
        {
            this.passwordData = passwordData;
        }
        public void OnGet(string searchTerm)
        {
            passwords = passwordData.GetPasswordByName(searchTerm);
        }
    }
}