using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Library.API;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
		private IProductEndPoint _productEndPoint;
		private BindingList<ProductModel> _products;
		private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();
		private ProductModel _selectedProduct;
		private int _itemQuantity = 1;

		public SalesViewModel(IProductEndPoint productEndPoint)
		{
			_productEndPoint = productEndPoint;
		}

		private async Task FillInProducts()
		{
			var allProducts = await _productEndPoint.GetAll();
			Products = new BindingList<ProductModel>(allProducts);
		}

		protected override async void OnViewLoaded(object view)
		{
			base.OnViewLoaded(view);
			await FillInProducts();
		}

		public BindingList<ProductModel> Products
		{
			get { return _products; }
			set 
			{ 
				_products = value;
				NotifyOfPropertyChange(() => Products);
			}
		}

		public ProductModel SelectedProduct
		{
			get { return _selectedProduct; }
			set 
			{ 
				_selectedProduct = value;
				NotifyOfPropertyChange(() => SelectedProduct);
				NotifyOfPropertyChange(() => CanAddToCart);
			}
		}


		public BindingList<CartItemModel> Cart
		{
			get { return _cart; }
			set
			{
				_cart = value;
				NotifyOfPropertyChange(() => Cart);
			}
		}

		public int ItemQuantity
		{
			get { return _itemQuantity; }
			set 
			{
				_itemQuantity = value;
				NotifyOfPropertyChange(() => ItemQuantity);
				NotifyOfPropertyChange(() => CanAddToCart);
			}
		}

		public string SubTotal
		{
			get
			{
				decimal subTotal = 0;

				foreach (CartItemModel oneCartItem in Cart)
				{
					subTotal += (oneCartItem.Product.RetailPrice * oneCartItem.ProductQuantity);
				}
				return subTotal.ToString("C"); ;
			}
		}

		public string Tax
		{
			get
			{
				//todo: Implement Tex
				return "$0.00";
			}
		}

		public string Total
		{
			get
			{
				//todo: Implement Total
				return "$0.00";
			}
		}

		public bool CanAddToCart
		{
			get 
			{
				//todo wordt niet aangepast als een nummer en daarna iets ongeldig wordt ingegeven (geen nummer)
				return (ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity);
			}
			
		}

		public void AddToCart()
		{
			CartItemModel existInCart = new CartItemModel();
			existInCart = Cart.FirstOrDefault(x => x.Product == SelectedProduct);

			if (existInCart != null)
			{
				existInCart.ProductQuantity += ItemQuantity;
				//todo: Refactory: Hack Er moet een betere manier hiervoor zijn
				Cart.Remove(existInCart);
				Cart.Add(existInCart);
			}
			else
			{
				CartItemModel newItemToCart = new CartItemModel { Product = SelectedProduct, ProductQuantity = ItemQuantity };
				Cart.Add(newItemToCart);
			}
			SelectedProduct.QuantityInStock -= ItemQuantity;

			//todo: Refactory: Hack Er moet een betere manier hiervoor zijn
			ProductModel dummyDisplay = SelectedProduct;
			Products.Remove(dummyDisplay);
			Products.Add(dummyDisplay);

			NotifyOfPropertyChange(() => Cart);
			NotifyOfPropertyChange(() => Products);
			NotifyOfPropertyChange(() => SubTotal);

			ItemQuantity = 1;
		}

		public bool CanRemoveFromCart()
		{
			bool output = true;

			//todo: Controlleer of er iets is geselecteerd

			return output;
		}

		public void RemoveFromCart()
		{
			//todo: Implementeer de knop AddToCart
			throw new NotImplementedException();
		}

		public bool CanCheckOut()
		{
			bool output = true;

			//todo: Controlleer of er iets in het winkelkarretje is

			return output;
		}

		public void CheckOut()
		{
			//todo: Implementeer de knop CheckOut
			throw new NotImplementedException();
		}
	}
}
