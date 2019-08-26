using System;
using System.Collections.Generic;
using System.Text;
using Vault.Core;

namespace Vault.Data
{
    public interface IPasswordData
    {
        IEnumerable<Password> GetPasswordByName(string name);
        Password GetPasswordById(int id);

        Password Update(Password updatedPassword);
        int Commit();
    }
    

}
