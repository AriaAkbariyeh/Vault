using System.Collections.Generic;
using Vault.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Vault.Data
{
    public class SqlPasswordData : IPasswordData
    {
        private readonly EntityFrameworkDBContext db;

        public SqlPasswordData(EntityFrameworkDBContext db)
        {
            this.db = db;
        }

        public Password Add(Password newPassword)
        {
            db.Add(newPassword);
            return newPassword;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Password Delete(int id)
        {
            var password = GetPasswordById(id);
            if (password != null)
            {
                db.Password.Remove(password);
            }

            return password;
        }

        public int GetCountOfPasswords()
        {
            return db.Password.Count();
        }

        public Password GetPasswordById(int id)
        {
            return db.Password.Find(id);
        }

        public IEnumerable<Password> GetPasswordByName(string name)
        {
            var q = from p in db.Password
                    where p.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                    orderby p.Name
                    select p;

            return q;
        }

        public Password Update(Password updatedPassword)
        {
            var entity = db.Password.Attach(updatedPassword);
            entity.State = EntityState.Modified;
            return updatedPassword;
        }
    }



}
