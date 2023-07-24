using FinalProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.NetworkModels
{
    public class bandNetworkModel
    {
        public int radif { get; set; }
        public int minutesnum { get; set; }
        public string matn { get; set; }
        public string subject { get; set; }
        public string result { get; set; }
        public string darmodrshakhs { get; set; }


        public bandNetworkModel cast(band input)
        {
            radif = input.radif;
            minutesnum = input.minutesnum;
            matn = input.matn;
            subject = input.subject;
            result = input.result;
            darmodrshakhs = input.darmodrshakhs;

            return this;
        }

        public band castTo(band input)
        {
            input.radif = radif;
            input.minutesnum = minutesnum;
            input.matn = matn;
            input.subject = subject;
            input.result = result;
            input.darmodrshakhs = darmodrshakhs;
            return input;
        }
    }
}