using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models.Context;

namespace FinalProject.Models.Repositories
{
    public interface UserRepo
    {
        void SaveUser(user user);
        void DeleteUser(user user);
        user FindUser(string codeMelli);
        void UpdateUser(user user);
        bool checkCredential(string codemelli,string password);
    }
}
