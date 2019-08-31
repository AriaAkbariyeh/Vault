﻿using System;
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
                new Password(){ _id = 1, Name = "MongoDB Atlas", Passphrase="Aria1234" },
                new Password(){ _id = 2, Name = "MongoDB Lab", Passphrase="Aria1234" },
                new Password(){ _id = 3, Name = "Azure", Passphrase="Aria1234" },
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
            return passwords.SingleOrDefault(p => p._id == id);
        }

        public Password Update(Password updatedPassword)
        {
            var password = passwords.SingleOrDefault(p => p._id == updatedPassword._id);
            if (password != null)
            {
                password.Name = updatedPassword.Name;
                password.Passphrase = updatedPassword.Passphrase;
            }
            return password;
        }

        public int Commit()
        {
            return 0;
        }

        public Password Add(Password newPassword)
        {
            passwords.Add(newPassword);
            newPassword._id = passwords.Max(p => p._id) + 1;
            return newPassword;
        }
    }
}
