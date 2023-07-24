using FinalProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.ViewModels.MinuteController
{
    public class AddSuratJalaseViewModel
    {
        public AddSuratJalaseViewModel()
        {
            typeha = new List<type>();
        }
        public List<type> typeha { get; set; }
    }
}