using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.Filters
{
    public class suratJalaseFilter
    {
        public bool IsSkippable { get; set; }
        public int skip { get; set; }
        public bool IsTakeable { get; set; }
        public int take { get; set; }

        /// <summary>
        /// این پرچم نشاندهنده این است که آیا این دسته از صورت جلسه هایی که خوانده میشوند،باید مربوط به کاربر خاصی باشند یا خیر 
        /// </summary>
        public bool IsUserRelated { get; set; }
        /// <summary>
        /// کدملی شخص
        /// </summary>
        public string userNumber { get; set; }
    }
}