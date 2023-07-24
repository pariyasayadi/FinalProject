using FinalProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.NetworkModels
{
    public class typeNetworkModel
    {
        public string tname { get; set; }
        public int numbertype { get; set; }


        public typeNetworkModel cast(type input)
        {
            tname = input.tname;
            numbertype = input.numbertype;

            return this;

        }
        public type castTo(type input)
        {
            input.tname =tname;
            input.numbertype =numbertype;

            return input;

        }
    }
}