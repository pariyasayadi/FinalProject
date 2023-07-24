using FinalProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models.Repositories
{
    public interface bandRepo
    {
        void SaveBand(band band);
        void DeleteBand(band band);
        band FindBand(int radifID, int minuteID);
    }
}
