using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Machine.Models.Blank;
using Machine.Models.Enum;
using Machine.Models.ViewModel;
using Machine.Service.Interface;

namespace Machine.Code
{
	public class Code
	{
		private IProductService _productService;
		private ICoinService _coinService;
		private IOrderService _orderService;

		private Converter.ConverterCoin.Converter _converterCoin = new Converter.ConverterCoin.Converter();
		private Converter.ConverterOrder.Converter _converterOrder = new Converter.ConverterOrder.Converter();
		private Converter.ConverterProduct.Converter _converterProduct = new Converter.ConverterProduct.Converter();
		
		public Code(IProductService productService, ICoinService coinService, IOrderService orderService)
		{
			_productService = productService;
			_coinService = coinService;
			_orderService = orderService;
		}

		public async Task AddProduct(ProductBlank blank)
		{
			await _productService.AddProduct(_converterProduct.ToDomain(blank));
		}

		public async Task UpdateProduct(ProductBlank blank)
		{
			await _productService.UpdateProduct(_converterProduct.ToDomain(blank));
		}

		public async Task UpdateProductCount(Int32 productId, Int32 count)
		{
			await _productService.UpdateProductCount(productId, count);
		}

		public async Task RemoveProduct(Int32 productId)
		{
			await _productService.RemoveProduct(productId);
		}

		public async Task RemoveProducts(Int32[] productIds)
		{
			await _productService.RemoveProducts(productIds);
		}

		public Task<ProductView> GetProduct(Int32 productId)
		{
			return Task.FromResult(_converterProduct.ToView(_productService.GetProduct(productId).Result));
		}

		public Task<List<ProductView>> GetProducts()
		{
			return Task.FromResult(_converterProduct.ToViews(_productService.GetProducts().Result));
		}

		public Task<List<ProductView>> GetProductsNotRemoved()
		{
			return Task.FromResult(_converterProduct.ToViews(_productService.GetProductsNotRemoved().Result));
		}

		public Task<List<ProductView>> GetProductsRemoved()
		{
			return Task.FromResult(_converterProduct.ToViews(_productService.GetProductsRemoved().Result));
		}

		public Task<List<ProductView>> GetProductsCategory(ProductCategory category)
		{
			return Task.FromResult(_converterProduct.ToViews(_productService.GetProductsCategory(category).Result));
		}

		public async Task BuyProduct(Int32 productId)
		{
			OrderBlank history = new OrderBlank() { ProductId = productId };
			await AddOperator(history);
			await _productService.BuyProduct(productId);
		}

		public async Task AddCoin(CoinBlank coin)
		{
			await _coinService.AddCoin(_converterCoin.ToDomain(coin));
		}

		public async Task UpdateMaxCoin(Int32 coinId, Int32 maxCoinCount)
		{
			await _coinService.UpdateMaxCoin(coinId, maxCoinCount);
		}

		public async Task UpdateNowCoin(Int32 coinId)
		{
			await _coinService.UpdateNowCoin(coinId);
		}

		public Task<CoinView> GetCoin(Int32 coinId)
		{
			return Task.FromResult(_converterCoin.ToView(_coinService.GetCoin(coinId).Result));
		}

		public Task<List<CoinView>> GetCoins()
		{
			return Task.FromResult(_converterCoin.ToViews(_coinService.GetCoins().Result));
		}

		/// <summary>
		/// Добавление истории
		/// </summary>
		private async Task AddOperator(OrderBlank blank)
		{
			await _orderService.AddOperator(_converterOrder.ToDomain(blank));
		}

		public Task<List<OrderView>> GetOrderHistory()
		{
			return Task.FromResult(_converterOrder.ToViews(_orderService.GetOrderHistory().Result));
		}
	}
}