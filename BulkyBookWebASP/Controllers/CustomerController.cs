using BulkyBookWebASP.Data;
using BulkyBookWebASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace BulkyBookWebASP.Controllers
{
	public class CustomerController : Controller
	{

		private readonly ApplicationDbContext _db;

		public CustomerController(ApplicationDbContext db)
		{ //what ever registered in the container can access here
			_db=db;
		}


		public IActionResult Index()
		{
			//pass this list to view and access there
			//var objCustomerList = _db.customers.ToList();
			IEnumerable<Customer> customerList = _db.customers;
			return View(customerList);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Customer obj)
		{

			if (obj.DisplayOrder < 10)
			{
				ModelState.AddModelError("CustomError", "The order qty should be atleast 10. ");
				ModelState.AddModelError("DisplayOrder", "The order qty should be atleast 10. ");
			}

			if (ModelState.IsValid)
			{

				//add the customer to the database
				_db.customers.Add(obj);
				_db.SaveChanges();

				//redirect to the Index action. If want can give the controller after the action name
				return RedirectToAction("Index");
			}
			return View(obj);
		}
	}
}
