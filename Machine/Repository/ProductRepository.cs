using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Machine.Models;
using Machine.Models.DBmodel;
using Machine.Models.Enum;
using Machine.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Machine.Repository
{
	public class ProductRepository: IProductRepository
	{
		private MachineDbContext _db;

		public ProductRepository(MachineDbContext db)
		{
			_db = db;
		}

		public async Task AddProduct(ProductDB productDb)
		{
			await _db.Product.AddAsync(productDb);
			await _db.SaveChangesAsync();
		}

		public async Task UpdateProduct(ProductDB product)
		{
			Task<ProductDB> productDb = _db.Product.FirstOrDefaultAsync(pr => pr.Id == product.Id);

			if (productDb != null)
			{
				productDb.Result.Name = product.Name;
				productDb.Result.Category = product.Category;
				productDb.Result.Description = product.Description;
				productDb.Result.Price = product.Price;
				productDb.Result.CountProduct = product.CountProduct;
			}

			await _db.SaveChangesAsync();
		}

		public async Task RemoveProduct(Int32 productId)
		{
			Task<ProductDB> productDb = _db.Product.FirstOrDefaultAsync(product => product.Id == productId);
			
			if (productDb != null)
			{
				productDb.Result.IsRemoved = true;
			}

			await _db.SaveChangesAsync();
		}

		public async Task UpdateProductCount(Int32 productId, Int32 count)
		{
			Task<ProductDB> productDb = _db.Product.FirstOrDefaultAsync(product => product.Id == productId);
			
			if (productDb != null)
			{
				productDb.Result.CountProduct = count;
			}

			await _db.SaveChangesAsync();
		}

		public async Task<ProductDB> GetProduct(Int32 productId)
		{
			Task<ProductDB> productDb = _db.Product.FirstOrDefaultAsync(product => product.Id == productId);

			return await productDb;
		}

		public async Task<List<ProductDB>> GetProducts()
		{
			Task<List<ProductDB>> productDbs = _db.Product.ToListAsync();

			return await productDbs;
		}

		public async Task<List<ProductDB>> GetProductsNotRemoved()
		{
			Task<List<ProductDB>> productDbs = _db.Product.Where(pr => pr.IsRemoved == false).ToListAsync();

			return await productDbs;
		}

		public async Task<List<ProductDB>> GetProductsRemoved()
		{
			Task<List<ProductDB>> productDbs = _db.Product.Where(pr => pr.IsRemoved == true).ToListAsync();

			return await productDbs;
		}

		public async Task<List<ProductDB>> GetProductsCategory(ProductCategory category)
		{
			Task<List<ProductDB>> productDbs = _db.Product.Where(pr => pr.Category == category).ToListAsync();

			return await productDbs;
		}
	}
}