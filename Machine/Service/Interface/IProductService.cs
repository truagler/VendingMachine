using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Machine.Models.Domain;
using Machine.Models.Enum;

namespace Machine.Service.Interface
{
	public interface IProductService
	{
		Task AddProduct(Product product);
		Task UpdateProduct(Product product);
		Task UpdateProductCount(Int32 productId, Int32 count);
		Task RemoveProduct(Int32 productId);
		Task RemoveProducts(Int32[] productIds);
		Task<Product> GetProduct(Int32 productId);
		Task<List<Product>> GetProducts();
		Task<List<Product>> GetProductsNotRemoved();
		Task<List<Product>> GetProductsRemoved();
		Task<List<Product>> GetProductsCategory(ProductCategory category);
		Task BuyProduct(Int32 productId);
	}
}