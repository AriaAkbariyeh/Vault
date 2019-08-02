﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Vault.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public RedirectToPageResult OnPost()
        {
            return new RedirectToPageResult(@"\vault\list");
        }
    }

}
