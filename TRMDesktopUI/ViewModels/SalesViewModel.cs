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
		private BindingList<ProductModel> _cart;
		private int _itemQuantity;

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

		public BindingList<ProductModel> Cart
		{
			get { return _cart; }
			set
			{
				_cart = value;
				NotifyOfPropertyChange(() => Products);
			}
		}

		public int ItemQuantity
		{
			get { return _itemQuantity; }
			set 
			{
				_itemQuantity = value;
				NotifyOfPropertyChange(() => Products);
			}
		}

		public string SubTotal
		{
			get
			{
				//todo: Implement SubTotal
				return "$0.00";
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

		public bool CanAddToCart()
		{
			bool output= true;

			//todo: Controlleer of er iets is geselecteerd en een hoeveelheid is ingegeven

			return output;
		}

		public void AddToCart()
		{
			//todo: Implementeer de knop AddToCart
			throw new NotImplementedException();
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
