using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Machine.Models.DBmodel;
using Machine.Models.Enum;

namespace Machine.Repository.Interface
{
	public interface IProductRepository
	{
		Task AddProduct(ProductDB productDb);
		Task UpdateProduct(ProductDB product);
		Task RemoveProduct(Int32 productId);
		Task UpdateProductCount(Int32 productId, Int32 count);
		Task<ProductDB> GetProduct(Int32 productId);
		Task<List<ProductDB>> GetProducts();
		Task<List<ProductDB>> GetProductsNotRemoved();
		Task<List<ProductDB>> GetProductsRemoved();
		Task<List<ProductDB>> GetProductsCategory(ProductCategory category);
	}
}