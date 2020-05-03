using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Models;
using TRMDesktopUI.Helper;

namespace TRMDesktopUI.Library.API
{
    public class ProductEndPoint : IProductEndPoint
    {
        private IAPIHelper _apiHelper;

        public ProductEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            using (HttpResponseMessage respons = await _apiHelper.ApiClient.GetAsync("/api/Product"))
            {
                if (respons.IsSuccessStatusCode)
                {
                    return await respons.Content.ReadAsAsync<List<ProductModel>>();
                }
                else
                {
                    throw new Exception(respons.ReasonPhrase);
                }
            }
        }
    }
}
