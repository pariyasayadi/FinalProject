using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models.Context;

namespace FinalProject.Models.Repositories
{
    public interface accessRepo
    {
        void SaveAccess(access access);
        void DeleteAccess(access access);
        access FindAccess(int type, string codemelli);
    }
}
