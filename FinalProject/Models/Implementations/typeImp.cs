using FinalProject.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.Context;
using FinalProject.Models.Filters;

namespace FinalProject.Models.Implementations
{
    public class typeImp : typeRepoo
    {
        private minutesEntities _context;

        public typeImp()
        {
            _context = new minutesEntities();
        }

        public void Deletetype(type type)
        {
            
            if (_context.types.Any(b => b == type))
            {
                _context.types.Remove(type);
                _context.SaveChanges();
            }
        }

        public type Findtype(int numbertype)
        {
            return _context.types.Find(numbertype);
        }

        public List<type> Filtertype(typeFilter filter)
        {
            var query = from b in _context.types
                        select b;
            return query.ToList();
        }

        public void Savetype(type type)
        {
            if (_context.types.Any(b => b == type))
            {
                return;
            }
            _context.types.Add(type);
            _context.SaveChanges();
        }

        public void Updatetype(type type)
        {
            var result = _context.types.Find(type);
            if (result == null)
            {
                return;
            }
            result = type;
            _context.SaveChanges();
        }
    }
}