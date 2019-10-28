using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vault.Core;

namespace Vault.Data
{
    public class EntityFrameworkDBContext : DbContext
    {
        public EntityFrameworkDBContext(DbContextOptions<EntityFrameworkDBContext> options)
            :base(options)
        {

        }

        public DbSet<Password> Password { get; set; }
    }
}
