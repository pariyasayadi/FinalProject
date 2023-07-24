using System.Collections.Generic;

namespace FinalProject.Models
{
    public static class StaticInfoes
    {
        public static Dictionary<int, string> ErrorCodes =
            new Dictionary<int, string>()
            {
                { 0, "Success" },
                { 1, "مشخصات کاربری اشتباه است!" },
                { 2, "باید ابتدا وارد حساب کاربری خود شوید" },
                { 3, "خطا در مقادیر ورودی" }
            };
    }
}