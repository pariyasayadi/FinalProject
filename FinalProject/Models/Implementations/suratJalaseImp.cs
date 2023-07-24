using FinalProject.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.Models.Context;
using FinalProject.Models.Filters;

namespace FinalProject.Models.Implementations
{
    public class suratJalaseImp : suratJalaseRepo
    {
        minutesEntities _context;

        public suratJalaseImp()
        {
            _context = new minutesEntities();
        }

        public List<suratJalase> AllSuratJalaseha()
        {
            return _context.suratJalases.ToList();
        }

        public void deleteSuratJalase(suratJalase surat)
        {
            if (_context.suratJalases.Any(b => b == surat))
            {
                _context.suratJalases.Remove(surat);
                _context.SaveChanges();
            }
        }

        public List<suratJalase> filterSuratJalaseha(suratJalaseFilter filter)
        {
            var query = from b in _context.suratJalases
                        select b;


            if (filter.IsUserRelated)
            {
                query = from b in _context.suratJalases
                        join c in _context.types on b.tnumber equals c.numbertype
                        join d in _context.accesses on c.numbertype equals d.num
                        join e in _context.users on d.codemelliuser equals e.codemelli
                        where e.codemelli == filter.userNumber
                        select b;
            }
            

            if (filter.IsSkippable)
            {
                query = query.OrderBy(b => new { b.mnumber, b.tnumber }).Skip(filter.skip);
            }

            if (filter.IsTakeable)
            {
                query = query.Take(filter.take);
            }


            return query.ToList();
        }

        public suratJalase findSuratJalase(int suratID)
        {
            return _context.suratJalases.Find(suratID);
        }

        public void saveSuratJalase(suratJalase surat,List<band> bandha)
        {
            if (_context.suratJalases.Any(b => b.mnumber == surat.mnumber))
            {
                return;
            }
            int Akharin =(int) _context.suratJalases.Where(b => b.tnumber == surat.tnumber).Select(b => b.chandomin).Max();
            surat.chandomin = Akharin + 1;
            _context.suratJalases.Add(surat);
            _context.SaveChanges();


            foreach (var item in bandha)
            {
                int lastRadifID = _context.bands.Where(b => b.minutesnum == surat.mnumber).Select(b => b.radif).Max();
                item.radif = lastRadifID + 1;
                _context.bands.Add(item);
            }
            _context.SaveChanges();
        }

        public void updateSuratJalase(int suratID, suratJalase newSurat)
        {
            var oldSurat = _context.suratJalases.Find(suratID);
            if (oldSurat == null)
            {
                return;
            }
            oldSurat = newSurat;
            _context.SaveChanges();
        }
    }
}