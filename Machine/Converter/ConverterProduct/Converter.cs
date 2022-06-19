using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Machine.Models.Blank;
using Machine.Models.DBmodel;
using Machine.Models.Domain;
using Machine.Models.ViewModel;

namespace Machine.Converter.ConverterProduct
{
	public class Converter
	{
		public ProductDB ToDb(Product product)
		{
			return  new ProductDB(product.Id, product.Name, product.CountProduct, product.Price, product.Description, product.Category, product.IsRemoved);
		}
		
		public List<ProductDB> ToDbs(List<Product> products)
		{
			return  products.Select(ToDb).ToList();
		}
		
		public Product ToDomain(ProductDB product)
		{
			return  new Product(product.Id, product.Name, product.CountProduct, product.Price, product.Description, product.Category, product.IsRemoved);
		}
		
		public Product ToDomain(ProductBlank product)
		{
			return  new Product(product.Id, product.Name, product.CountProduct, product.Price, product.Description, product.Category, product.IsRemoved);
		}
		
		public List<Product> ToDomains(List<ProductDB> products)
		{
			return  products.Select(ToDomain).ToList();
		}

		public ProductView ToView(Product product)
		{
			return new ProductView(product.Id, product.Name, product.CountProduct, product.Price, product.Description,
				product.Category, product.IsRemoved);
		}

		public List<ProductView> ToViews(List<Product> products)
		{
			return products.Select(ToView).ToList();
		}
	}
}