using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Helpers;

namespace TRMDesktopUI.Library.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal RetailPrice { get; set; }
        public int QuantityInStock { get; set; }
        public bool IsTaxAble { get; set; }
        public decimal TaxPrice
        {
            get
            {
                if (IsTaxAble )
                {
                    decimal taxPercent = ConfigHelper.TaxPercentGet();

                    return Math.Round(RetailPrice * (taxPercent / 100), 4);
                }
                else
                {
                    return 0;
                }
            }
        }

    }
}
