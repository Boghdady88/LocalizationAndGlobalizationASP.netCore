using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace WebApplication
{
    public partial class AppSession
    {
        public AppSession()
        {
        }
        public static bool IsArabic { get; set; } = true;
        public static bool IsEngligh { get; set; } = false;
        public static bool IsTurkish { get; set; } = false;

    }
}
