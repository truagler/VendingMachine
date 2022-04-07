using System;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Models.ViewModel;
using WebApplication1.Models.Code;
using WebApplication1.Models.Enum;
using WebApplication1.Models.Interfaces;

namespace VendingMachine.Controllers
{
	public class HomeController : Controller
	{
		private readonly DrinkAndEatCode _code;

		public HomeController(ServiceInterface serviceInterface)
		{
			_code = new DrinkAndEatCode(serviceInterface);
		}
		
		public ActionResult Index()
		{
			DrinkAndCodeViewModel models = _code.GetProducts();
			
			return View(models);
		}

		public ActionResult Privacy()
		{
			DrinkAndCodeViewModel models = _code.GetProducts();
			
			return View(models);
		}

		[HttpPost]
		[Route("/addproduct")]
		public void AddProduct(String productName, Int32 price, String img)
		{
			_code.AddProduct(productName, price, img);
		}

		[HttpPost]
		[Route("/editproduct")]
		public void EditProduct(Int32 id, String productName, Int32 price, String img)
		{
			_code.EditProduct(id, productName, price, img);
		}

		[HttpPost]
		[Route("/removeproduct")]
		public void RemoveProduct(Int32 id)
		{
			_code.RemoveProduct(id);
		}

		[HttpGet]
		[Route("/getproduct")]
		public DrinkAndCodeViewModel GetProduct(Int32 id)
		{
			DrinkAndCodeViewModel model = _code.GetProduct(id);

			return model;
		}

		public DrinkAndCodeViewModel GetProducts()
		{
			DrinkAndCodeViewModel models = _code.GetProducts();

			return models;
		}

		[HttpPost]
		[Route("/clickcoin")]
		public void ClickCoin(Int32 id, Coin coin)
		{
			_code.ClickCoin(id, coin);
		}

		[HttpPost]
		[Route("/buyproduct")]
		public void BuyProduct(Int32 id)
		{
			_code.BuyProduct(id);
		}
	}
}