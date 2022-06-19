using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Machine.Models.DBmodel;
using Machine.Models.Domain;
using Machine.Models.Enum;
using Machine.Repository.Interface;
using Machine.Service.Interface;
using Machine.Tools;

namespace Machine.Service
{
	public class ProductService: IProductService
	{
		private IProductRepository _productRepository;

		private Converter.ConverterProduct.Converter _converter = new Converter.ConverterProduct.Converter();

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task AddProduct(Product product)
		{
			product.Id = ID.NewID();
			await _productRepository.AddProduct(_converter.ToDb(product));
		}

		public async Task UpdateProduct(Product product)
		{
			await _productRepository.UpdateProduct(_converter.ToDb(product));
		}

		public async Task UpdateProductCount(Int32 productId, Int32 count)
		{
			await _productRepository.UpdateProductCount(productId, count);
		}

		public async Task RemoveProduct(Int32 productId)
		{
			await _productRepository.RemoveProduct(productId);
		}

		public async Task RemoveProducts(Int32[] productIds)
		{
			foreach (Int32 productId in productIds)
			{
				await RemoveProduct(productId);
			}
		}

		public Task<Product> GetProduct(Int32 productId)
		{
			Task<ProductDB> product = _productRepository.GetProduct(productId);

			return Task.FromResult(_converter.ToDomain(product.Result));
		}

		public Task<List<Product>> GetProducts()
		{
			Task<List<ProductDB>> product = _productRepository.GetProducts();

			return Task.FromResult(_converter.ToDomains(product.Result));
		}

		public Task<List<Product>> GetProductsNotRemoved()
		{
			Task<List<ProductDB>> product = _productRepository.GetProductsNotRemoved();

			return Task.FromResult(_converter.ToDomains(product.Result));
		}

		public Task<List<Product>> GetProductsRemoved()
		{
			Task<List<ProductDB>> product = _productRepository.GetProductsRemoved();

			return Task.FromResult(_converter.ToDomains(product.Result));
		}

		public Task<List<Product>> GetProductsCategory(ProductCategory category)
		{
			Task<List<ProductDB>> product = _productRepository.GetProductsCategory(category);

			return Task.FromResult(_converter.ToDomains(product.Result));
		}

		public async Task BuyProduct(Int32 productId)
		{
			Int32 count = GetProduct(productId).Result.CountProduct - 1;
			
			await UpdateProductCount(productId, count);
		}
	}
}