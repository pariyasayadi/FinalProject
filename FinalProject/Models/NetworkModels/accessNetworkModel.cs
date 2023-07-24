using FinalProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.NetworkModels
{
    public class accessNetworkModel
    {
        public int num { get; set; }
        public string codemelliuser { get; set; }
        public Nullable<int> fake { get; set; }


        public accessNetworkModel cast(access input)
        {
            num = input.num;
            codemelliuser = input.codemelliuser;
            fake = input.fake;

            return this;
        }
        public access castTo(access input)
        {

            input.num = num;
            input.codemelliuser = codemelliuser;
            input.fake = fake;

            return input;

        }
    }
}