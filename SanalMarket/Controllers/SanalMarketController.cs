using Microsoft.AspNetCore.Mvc;
using SanalMarket.Context;
using SanalMarket.Data;
using SanalMarket.Models;

namespace SanalMarket.Controllers
{
    public class SanalMarketController : Controller
    {
        private readonly SanalMarketDbContext _db;
        Product product = new Product();

        public SanalMarketController(SanalMarketDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Products.ToList());
        }

        public IActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddNewProduct(ProductViewModel pvm)
        {
            if (!ModelState.IsValid) return View();
            
            product.Name = pvm.Name;
            product.Price = pvm.Price;
            product.StockQuantity = pvm.StockQuantity;

            if(pvm.Image != null)
            {
                product.ImageName = pvm.Image.FileName;
                var konum = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", pvm.Image.FileName);
                var akisOrtami = new FileStream(konum, FileMode.Create);
                pvm.Image.CopyTo(akisOrtami);
                akisOrtami.Close();
            }

            _db.Products.Add(product);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Remove(int id)
        {
            Product? removedProduct = _db.Products.Find(id);
            return View(removedProduct);
        }

        [ActionName("Remove")]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ConfirmRemove(Product product)
        {
            if (!ModelState.IsValid) return View();

            //Product removedProduct = _db.Products.FirstOrDefault(x => x.Id



            return RedirectToAction("Index");




        }


    }
}
