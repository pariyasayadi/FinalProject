using FinalProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.NetworkModels
{
    public class suratJalaseNetworkModel
    {
        public int mnumber { get; set; }
        public int tnumber { get; set; }
        public Nullable<int> chandomin { get; set; }
        public System.DateTime date { get; set; }


        public suratJalaseNetworkModel cast(suratJalase input)
        {
            mnumber = input.mnumber;
            tnumber = input.tnumber;
            chandomin = input.chandomin;
            date= input.date;

            return this;
        }

        public suratJalase castTo(suratJalase input)
        {
            input.mnumber = mnumber;
            input.tnumber = tnumber;
            input.chandomin =chandomin;
            input.date = date;

            return input;
        }
    }
}