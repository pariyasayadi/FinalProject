using FinalProject.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.Context;

namespace FinalProject.Models.Implementations
{
    public class bandImp : bandRepo
    {
        private minutesEntities _context;

        public bandImp()
        {
            _context = new minutesEntities();
        }


        public void DeleteBand(band band)
        {
            if (_context.bands.Any(b=>b==band))
            {
                _context.bands.Remove(band);
                _context.SaveChanges();
            }
        }

        public band FindBand(int radifID, int minuteID)
        {
            return _context.bands.Where(b => b.radif == radifID && b.minutesnum == minuteID).FirstOrDefault();
        }

        public void SaveBand(band band)
        {
            if (_context.bands.Any(b=>b==band))
            {
                return;
            }
            _context.bands.Add(band);
            _context.SaveChanges();
        }
    }
}