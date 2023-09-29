using BulkyBookWebASP.Data;
using BulkyBookWebASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWebASP.Controllers
{
    public class CategoryController : Controller
    {
        /***
         * We are using EntityFrameworkCore, the main file is ApplicationDbContext and using that can access database objects.
         * Creating an object of DbContext and useing it to access database and teables is  task of dependency injection
         * 
         */

        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
            //can access whatever is registered in the container. An implementation of the ApplicationDbContext
            //it has everything to access data
        }
        public IActionResult Index()
        {
            //goes to the database and fetch the categories and convert to a list
            //var objcategoryList = _db.categories.ToList();
            IEnumerable<Category> objcategoryList = _db.categories;
            //sending and IEnumerable of category to the view
            return View(objcategoryList);
        }

        public IActionResult Create()
        {         
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            double res = 0;
            if (!double.TryParse(obj.DisplayOrder.ToString(),out res)){
                ModelState.AddModelError("NumericValidation", "Display order should be a numeric value.");
            }
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and display order shold not be the same.");
            }
            if (ModelState.IsValid)
            {

                //add to the database
                _db.categories.Add(obj);
                _db.SaveChanges();

                //redirect to an action, Index action of the same controller
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
