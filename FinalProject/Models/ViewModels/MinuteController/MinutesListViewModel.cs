using FinalProject.Models.Context;
using System.Collections.Generic;

namespace FinalProject.Models.ViewModels.MinuteController
{
    public class SuratJalaseListViewModel
    {
        public SuratJalaseListViewModel()
        {
            suratJalaseha = new List<suratJalase>();
        }
        public List<suratJalase> suratJalaseha { get; set; }
    }
}