using System;
using System.Linq;
using FinalProject.Models.Context;
using FinalProject.Models.Repositories;

namespace FinalProject.Models.Implementations
{
    public class UserImp : UserRepo
    {
        private minutesEntities _context;
        public UserImp()
        {
            _context = new minutesEntities();
        }

        public bool checkCredential(string codemelli, string password)
        {
            var user = _context.users.Find(codemelli);

            if (user == null) return false;
            if (user.password != password)return false;

            return true;
        }

        public void DeleteUser(user user)
        {
            if (_context.users.Any(b => b.codemelli == user.codemelli))
            {
                _context.users.Remove(user);
                _context.SaveChanges();
            }
        }

        public user FindUser(string codeMelli)
        {
            return _context.users.Find(codeMelli);
        }

        public void SaveUser(user user)
        {
            if (_context.users.Any(b=>b.codemelli==user.codemelli))
            {
                return;
            }
            _context.users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(user user)
        {
            var member = _context.users.Find(user);
            if (member==null)
            {
                return;
            }
            member = user;
            _context.SaveChanges();
        }
    }
}
