using E_COMMERCE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_COMMERCE.Controllers
{
    [Authorize(Roles =("Admin"))]
      public class productController : Controller
    {
        public IActionResult Index()
        {
         Commerce2Context commerceContext = new Commerce2Context();
          var product = commerceContext.Cetogeries.Select(x => new { x.Id, x.Name }).ToList();
           ViewBag.data =new SelectList(product, "Id", "Name");
            return View();
        }
        public IActionResult admain() => View();


        [HttpPost]
        public IActionResult create(productvm model)
        {
            Commerce2Context commerce2=new Commerce2Context();
             var item= commerce2.Cetogeries.Select(x => new { x.Name, x.Id })
                .ToList();
            ViewBag.data = new SelectList(item, "Name", "id");
            if (ModelState.IsValid)
            {
                
            
           Commerce2Context commerceContext = new Commerce2Context();
            Cetogery cetogery = new Cetogery();
            cetogery.Name = model.catname;
            commerceContext.Add(cetogery);
                commerceContext.Products.Add(new Product
                {
                    Name = model.productname,
                    Price = model.productprice,
                    Productquntity = model.productquntity,
                    CeitoNavigation = cetogery,
                });
                   
             

                commerceContext.SaveChanges();
                
    
        
            return RedirectToAction( "Index");
            }

            return View("Index", model);
        } 
        
    }
    


    }
 
    

