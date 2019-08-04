using System;
using System.Collections.Generic;
using System.Text;
using Vault.Core;
using System.Linq;

namespace Vault.Data
{
    public class InMemoryPasswordData : IPasswordData
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

        public IEnumerable<Password> GetPasswordByName(string name = null)
        {
            string loweredCaseName = null;
            if (!string.IsNullOrEmpty(name))
            {
                loweredCaseName = name.ToLower();
            }
             
            return from p in passwords
                   where string.IsNullOrEmpty(loweredCaseName) ||  p.Name.ToLower().StartsWith(loweredCaseName)
                   orderby p.Name
                   select p;
        }

        public Password GetPasswordById(int id)
        {
            return passwords.SingleOrDefault(r => r.Id == id);
        }
    }
}
