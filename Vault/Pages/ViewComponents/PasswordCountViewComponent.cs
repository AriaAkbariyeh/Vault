using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vault.Data;

namespace Vault.Pages.ViewComponents
{ 
    public class PasswordCountViewComponent : ViewComponent
    {
        private readonly IPasswordData passwordData;

        public PasswordCountViewComponent(IPasswordData passwordData)
        {
            this.passwordData = passwordData;
        }

        public IViewComponentResult Invoke()
        {
            var count = passwordData.GetCountOfPasswords();
            return View(count);
        }
    }
}
