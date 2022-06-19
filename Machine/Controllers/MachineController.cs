using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Machine.Models.Blank;
using Machine.Models.Enum;
using Machine.Models.PostModel;
using Machine.Models.ViewModel;
using Machine.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Machine.Controllers
{
	public class MachineController: ControllerBase
	{
		private Code.Code _code;

		public MachineController(IProductService productService, ICoinService coinService, IOrderService orderService)
		{
			_code = new Code.Code(productService, coinService, orderService);
		}

		[HttpPost]
		[Route("addproduct")]
		public async Task AddProduct([FromBody] ProductBlank blank)
		{
			await _code.AddProduct(blank);
		}

		[HttpPost]
		[Route("updateproduct")]
		public async Task UpdateProduct([FromBody] ProductBlank blank)
		{
			await _code.UpdateProduct(blank);
		}

		[HttpPost]
		[Route("updateproductcount")]
		public async Task UpdateProductCount([FromBody] UpdateProductCount data)
		{
			await _code.UpdateProductCount(data.ProductId, data.Count);
		}

		[HttpPost]
		[Route("removeproduct")]
		public async Task RemoveProduct([FromBody] Int32 productId)
		{
			await _code.RemoveProduct(productId);
		}

		[HttpPost]
		[Route("removeproducts")]
		public async Task RemoveProducts([FromBody] Int32[] productIds)
		{
			await _code.RemoveProducts(productIds);
		}

		[HttpGet]
		[Route("getproduct/{productId?}")]
		public Task<ProductView> GetProduct(Int32 productId)
		{
			return _code.GetProduct(productId);
		}

		[HttpGet]
		[Route("getproducts")]
		public Task<List<ProductView>> GetProducts()
		{
			return _code.GetProducts();
		}

		[HttpGet]
		[Route("getproductsnotremoved")]
		public Task<List<ProductView>> GetProductsNotRemoved()
		{
			return _code.GetProductsNotRemoved();
		}

		[HttpGet]
		[Route("getproductsremoved")]
		public Task<List<ProductView>> GetProductsRemoved()
		{
			return _code.GetProductsRemoved();
		}

		[HttpGet]
		[Route("getproductscategory/{category?}")]
		public Task<List<ProductView>> GetProductsCategory(ProductCategory category)
		{
			return _code.GetProductsCategory(category);
		} 
		
		[HttpPost]
		[Route("buyproduct")]
		public async Task BuyProduct([FromBody] Int32 productId)
		{
			await _code.BuyProduct(productId);
		} 
		
		[HttpPost]
		[Route("updatemaxcoin")]
		public async Task UpdateMaxCoin([FromBody] UpdateMaxCoin data)
		{
			await _code.UpdateMaxCoin(data.CoinId, data.MaxCoinCount);
		}
		
		[HttpPost]
		[Route("updatecoinnow")]
		public async Task UpdateNowCoin([FromBody] Int32 coinId)
		{
			await _code.UpdateNowCoin(coinId);
		}

		[HttpGet]
		[Route("getcoin/{coinId?}")]
		public Task<CoinView> GetCoin(Int32 coinId)
		{
			return _code.GetCoin(coinId);
		} 

		[HttpGet]
		[Route("getcoins")]
		public Task<List<CoinView>> GetCoins()
		{
			return _code.GetCoins();
		}

		[HttpGet]
		[Route("getorderhistory")]
		public Task<List<OrderView>> GetOrderHistory()
		{
			return _code.GetOrderHistory();
		} 
	}
}