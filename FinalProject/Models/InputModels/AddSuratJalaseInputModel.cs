using FinalProject.Models.NetworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.InputModel
{
    public class AddSuratJalaseInputModel
    {
        public AddSuratJalaseInputModel()
        {
            suratJalase = new suratJalaseNetworkModel();
            bandha = new List<bandNetworkModel>();
        }
        public suratJalaseNetworkModel suratJalase { get; set; }
        public List<bandNetworkModel> bandha { get; set; }
    }
}