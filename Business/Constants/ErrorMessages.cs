using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class ErrorMessages
    {
        private static string maintenanceTime = "Sistem bakımda";
        private static string productNameInvalid = "Ürün ismi geçersiz";

        public static string MaintenanceTime { get => maintenanceTime; set => maintenanceTime = value; }
        public static string ProductNameInvalid { get => productNameInvalid; set => productNameInvalid = value; }

    }
}
