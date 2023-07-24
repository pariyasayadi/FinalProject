using FinalProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.NetworkModels
{
    public class userNetworkModel
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string codemelli { get; set; }
        public string phonnumber { get; set; }
        public string password { get; set; }

        public userNetworkModel cast(user input)
        {
            fname = input.fname;
            lname = input.lname;
            codemelli = input.codemelli;
            phonnumber = input.phonnumber;
            password = input.password;

            return this;
        }
        public user castTo(user input)
        {
            input.fname = fname;
            input.lname =lname;
            input.codemelli = codemelli;
            input.phonnumber = phonnumber;
            input.password = password;

            return input;
        }
    }
}