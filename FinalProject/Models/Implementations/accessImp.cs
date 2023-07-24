using FinalProject.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.Context;

namespace FinalProject.Models.Implementations
{
    public class accessImp : accessRepo
    {
        public minutesEntities _context { get; set; }

        public accessImp()
        {
            _context = new minutesEntities();
        }


        /// <summary>
        /// تابعی برای حذف دسترسی
        /// </summary>
        /// <param name="access"></param>
        public void DeleteAccess(access access)
        {
            if (_context.accesses.Any(b=>b==access))
            {
                _context.accesses.Remove(access);
                _context.SaveChanges();
            }
        }

        public access FindAccess(int type, string codemelli)
        {
            return _context.accesses.Where(b => b.codemelliuser == codemelli && b.num == type).FirstOrDefault();
        }

        public void SaveAccess(access access)
        {
            if (_context.accesses.Any(b=>b==access))
            {
                return;
            }
            _context.accesses.Add(access);
            _context.SaveChanges();
        }
        
    }
}