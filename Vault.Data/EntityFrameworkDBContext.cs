using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vault.Core;

namespace Vault.Data
{
    class EntityFrameworkDBContext : DbContext
    {
        public DbSet<Password> Password { get; set; }
    }
}
