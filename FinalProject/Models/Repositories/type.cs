using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models.Context;
using FinalProject.Models.Filters;

namespace FinalProject.Models.Repositories
{
   public interface typeRepoo
    {
        void Savetype(type type);
        void Deletetype(type type);
        type Findtype(int numbertype);
        List<type> Filtertype(typeFilter filter);
        void Updatetype(type type);
    }
}
