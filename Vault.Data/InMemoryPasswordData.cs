using System;
using System.Collections.Generic;
using System.Text;
using Vault.Core;
using System.Linq;

namespace Vault.Data
{
    class InMemoryPasswordData : IPasswordData
    {
        readonly List<Password> passwords;
        public InMemoryPasswordData()
        {
            passwords = new List<Password>()
            {
                new Password(){ Id = 1, Name = "MongoDB Atlas", Passphrase="Aria1234" },
                new Password(){ Id = 2, Name = "MongoDB Lab", Passphrase="Aria1234" },
                new Password(){ Id = 3, Name = "Azure", Passphrase="Aria1234" },
            };
        }

        public IEnumerable<Password> GetAll()
        {
            return from r in passwords
                   orderby r.Name
                   select r;
        }
    }
}
