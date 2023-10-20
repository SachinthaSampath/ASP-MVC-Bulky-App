using BulkyBookWebASP.Data;
using BulkyBookWebASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWebASP.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _db;
		public ProductController(ApplicationDbContext db)
		{
			_db = db;
		}

		//GET
		public IActionResult Index()
		{
			IEnumerable<Product> productList = _db.products;
			return View(productList);
		}

		//GET
		public IActionResult Create()
		{
			return View();
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Product obj)
		{
			if (obj.Name.Length < 10)
			{
				ModelState.AddModelError("Name", "Name should be more than 10 characters");
			}

			if (ModelState.IsValid)
			{
				_db.products.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}


		//GET
		public IActionResult Edit(int? id)
		{
			if(id == null || id == 0)
			{
				return NotFound();
			}
			var product = _db.products.Find(id);
			//var product = _db.products.SingleOrDefault(u => u.Id == id);
			//var product = _db.products.FirstOrDefault(u => u.Id == id);
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Product obj)
		{
			if (obj.Name.Length < 10)
			{
				ModelState.AddModelError("Name", "Name should be more than 10 characters");
			}

			if (ModelState.IsValid)
			{
				_db.products.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}
	}
}
