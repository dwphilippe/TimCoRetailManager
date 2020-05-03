using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Models
{
    public class CartItemModel
    {
        public ProductModel Product { get; set; }
        public int ProductQuantity { get; set; }

        public string DisplayName
        {
            get
            {
                return $"{ Product.ProductName } ({ ProductQuantity })";
            }
        }
    }
}
