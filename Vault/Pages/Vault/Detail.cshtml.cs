using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vault.Core;

namespace Vault.Pages.Vault
{
    public class DetailModel : PageModel
    {
        public Password Password{ get; set; }

        public void OnGet()
        {
            Password = new Password();
        }
    }
}