using E_COMMERCE.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace E_COMMERCE.Controllers;


using E_COMMERCE.Models; // Cart, Product
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using Order = Models.Order;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly Commerce2Context commerceContext;
    private readonly UserManager<E_COMMERCEUser> _userManager;
    private readonly PayPalHttpClient _payPalClient;
    public HomeController(ILogger<HomeController> logger, Commerce2Context context, UserManager<E_COMMERCEUser> userManager,PayPalHttpClient paypalClient)
    {
        _logger = logger;
        commerceContext = context;
        _userManager = userManager;
        _payPalClient = paypalClient;
    }
    //طريقه لعرض اكتر من بيانات بس مش احسن حاجه
    //public IActionResult Index()
    //{
    //    CommerceContext pr = new CommerceContext();
    //    var proudect = pr.Cetogeries.ToList();
    //    ViewBag.card=pr.Products.ToList();
    //    return View(proudect);
    //}
    public IActionResult Index()
    {
        Commerce2Context pr = new Commerce2Context();
        Indexvm result = new Indexvm();
        result.Cetogeries = pr.Cetogeries.ToList();
        result.Products = pr.Products.ToList();
        result.Reviews2= pr.Review2s.ToList();
        result.lastproduct = pr.Products.OrderByDescending(x => x.Entitydata).Take(3).ToList();
        ViewBag.isadmain = true;
        result.Reviews2=pr.Review2s.OrderByDescending(x=>x.CreatedAt).ToList();
        result.carts = pr.Carts.ToList();
        return View(result);
      
    }
    public IActionResult Privacy() => View();

    public IActionResult cegtogray()
    {

        var product = commerceContext.Cetogeries.ToList();
        return View(product);
    }
    public IActionResult product(int id)
    {

        var product = commerceContext.Products.Where(x => x.Ceito == id).ToList();
        return View(product);
    }

    public IActionResult productcurrent(int id)
    {

        var product = commerceContext.Products.Include(x => x.CeitoNavigation).Include(x => x.Productimages).Include(x=>x.Review2s)
            .FirstOrDefault(x => x.Id == id);
        return View(product);
    }

    public IActionResult productsearch(String xname)
    {
        var product = new List<Product>();
        if (String.IsNullOrEmpty(xname))
        {
            product = commerceContext.Products.ToList();
        }
        else
        {
            product = commerceContext.Products.Where(x => x.Name.Contains(xname)).ToList();

        }
        return View(product);
    }



    [Authorize]
    public IActionResult GetCart()
    {
       


        // 1️⃣ جلب المستخدم الحالي
        var count = commerceContext.Carts.Where(c=>c.Userid == User.Identity.Name)
                  .Sum(x=>x.Quntity)  ;

        // 3️⃣ رجع القائمة للـ View
        return Json(count);
    }

    


    [Authorize]
        public IActionResult Cart()
        {
            // 1️⃣ جلب المستخدم الحالي
            var user = commerceContext.AspNetUsers
                        .FirstOrDefault(u => u.UserName == User.Identity.Name);
        
        if (user == null)
            {
                // المستخدم مش موجود، رجع قائمة فاضية
                return View(new List<Cart>());
            }

            // 2️⃣ جلب عناصر الكارت للمستخدم الحالي
            var cartItems = commerceContext.Carts
                            .Include(c => c.Product)
                            .Where(c => c.Userid == user.UserName) // أو user.Id حسب ما مخزن
                            .ToList();

            // 3️⃣ رجع القائمة للـ View
            return View(cartItems);
        }

    [Authorize]
    public IActionResult AddToCart(int id)
    {
            var price = commerceContext.Products.Find(id)?.Price;
        // Convert User.Identity.Name to string and compare with Cart.Userid (which should be string)
        var userId = User.Identity?.Name;
        if (string.IsNullOrEmpty(userId))
        {
            // Handle unauthenticated user
            return Unauthorized();
        }
        var item = commerceContext.Carts.FirstOrDefault(x => x.Productid == id && x.Userid == userId);
        if (item is not null)
        {
            item.Quntity = (item.Quntity ?? 0) + 1;
            commerceContext.SaveChanges();
        }
        else
        {
            commerceContext.Carts.Add(new Cart { Productid = id, Userid = userId, Price = price, Quntity = 1 });
            commerceContext.SaveChanges();
        }


        return RedirectToAction("cart");
    }

    public IActionResult removefromCart(int id)
    {
        var userId = User.Identity?.Name;
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }
        var item = commerceContext.Carts.FirstOrDefault(x => x.Productid == id && x.Userid == userId);
        if (item is not null)
        {
            if ((item.Quntity ?? 0) > 1)
            {
                item.Quntity -= 1;
            }
            else
            {
                commerceContext.Carts.Remove(item);
            }
            commerceContext.SaveChanges();
        }
        return RedirectToAction("cart");
    }

    //دى لما بعمل GET
    //public IActionResult sendrieview(String Name, string Email ,string Subject, string Description )
    //{

    //    commerceContext.Reviews.Add(new Review { Name = Name, Email = Email, Subject = Subject, Description = Description });
    //    commerceContext.SaveChanges();
    //    return RedirectToAction("Index");
    //}
    [HttpPost]
    public IActionResult sendrieview(Review model)
    {

        commerceContext.Reviews.Add(new Review { Name = model.Name, Email = model.Email, Subject = model.Subject, Description = model.Description});
        commerceContext.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult sendrieview2(Review2 model)
    {
        if (model is null)
        {
            TempData["erro message"] = "required!";
            return RedirectToAction("productcurrent", new { id = model.ProductId });
        }

        commerceContext.Review2s.Add(new Review2 { CreatedAt = DateTime.Now, Name = model.Name, Description = model.Description, Rating = model.Rating ,Email=model.Email,Subject=model.Subject,ProductId= model.ProductId });
            commerceContext.SaveChanges();
            TempData["sucessfulmessage"]= "Your review has been submitted. Thank you!";
            return RedirectToAction("productcurrent", new {id=model.ProductId});
        
        
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult CompleteCarts()
    {
        var item1 = commerceContext.Carts
      .Where(x => x.Userid == User.Identity.Name)
      .ToList();

        // لو الكارت فاضي
        if (!item1.Any())
        {
            TempData["CartError"] = "السلة فارغة! من فضلك أضف منتجات أولاً.";

            // نرجع لنفس الصفحة أو نرجع لصفحة الكارت
            return RedirectToAction("Cart");
            // أو لو عايزة يفضل في نفس صفحة الـ Checkout اكتبي:
            // return View("Completecarts", model);
        }

        ViewBag.Countries = new SelectList(commerceContext.Countries.ToList(), "Id", "Name");
        ViewBag.States = new SelectList(commerceContext.States.ToList(), "Id", "Name");
        ViewBag.Cities = new SelectList(commerceContext.Cities.ToList(), "Id", "Name");

        return View(new Order());
    }   

    // POST: استلام الطلب
    [HttpPost]
    [Authorize]

    public IActionResult CompleteCarts(Order model)
    {

      
        if (!ModelState.IsValid)
        {
            ViewBag.Countries = new SelectList(commerceContext.Countries.ToList(), "Id", "Name");
            ViewBag.States = new SelectList(commerceContext.States.ToList(), "Id", "Name");
            ViewBag.Cities = new SelectList(commerceContext.Cities.ToList(), "Id", "Name");
            return View(model);
        }
       
        var items = commerceContext.Carts.Where(x => x.Userid == User.Identity.Name).ToList();

        if (!items.Any())
        {
            ModelState.AddModelError("", "لم يتم إضافة أي منتجات إلى الطلب.");
            ViewBag.Countries = new SelectList(commerceContext.Countries.ToList(), "Id", "Name");
            ViewBag.States = new SelectList(commerceContext.States.ToList(), "Id", "Name");
            ViewBag.Cities = new SelectList(commerceContext.Cities.ToList(), "Id", "Name");
            return View(model);
        }

        // إنشاء الطلب
        var order = new Order
        {
            CustomerName = model.CustomerName,
            Phone = model.Phone,
          Address= model.Address,
            CountryId = model.CountryId,
            StateId = model.StateId,
            CityId = model.CityId,
            Onlinepaid = model.Onlinepaid, // جاي من الـ form
            Userid = User.Identity.Name,
            OrderDate = DateTime.Now
        };

        foreach (var item in items)
        {
            order.Orderdetials.Add(new Orderdetial
            {
                Productid = item.Productid,
                Quantity = item.Quntity,
                
                Price = item.Price,
                Totalprice = item.Price * item.Quntity
            });
        }

        commerceContext.RemoveRange(items);
        commerceContext.Orders.Add(order);
        commerceContext.SaveChanges();
        if (model.Onlinepaid==true) // true → أونلاين
        {
            // Redirect لصفحة Checkout/OnlinePayment
            return RedirectToAction("Payment", "Home", new { orderId = order.Id });

        }
        else
        {
            // عند الاستلام → Success Page مباشرة
            return RedirectToAction("Success", new { id = order.Id });
        }
        // توجيه لصفحة النجاح
       
    }

    // صفحة نجاح الطلب
    public IActionResult Success(int id)
    {
        var order = commerceContext.Orders
            .Include(x => x.Orderdetials).ThenInclude(y => y.Product)
            .Include(x => x.City)
            .Include(x => x.Country)
            .FirstOrDefault(x => x.Id == id);

        if (order is null) return NotFound();

        return View(order);
    }
    [HttpGet]
    public IActionResult Payment(int orderId) => RedirectToAction("OnlinePayment", "Home", new { orderId = orderId });

    [HttpPost,HttpGet]
    public async Task<IActionResult> OnlinePayment(int orderId)
    {
        var order = commerceContext.Orders
            .Include(o => o.Orderdetials)
            .ThenInclude(od => od.Product)
            .FirstOrDefault(o => o.Id == orderId);

        if (order == null)
            return NotFound();

        // Calculate total amount safely (handle nullable price/quantity)
        decimal totalAmount = order.Orderdetials
            .Sum(od => (od.Price ?? 0m) * (decimal)(od.Quantity ?? 0));

        // Create Payment record in DB
        var payment = new Payment
        {
            OrderId = order.Id,
            Provider = "PayPal",
            Amount = totalAmount,
            Currency = "USD",
            Status = "Pending",
            CreatedAt = DateTime.Now
        };

        commerceContext.Payments.Add(payment);
        await commerceContext.SaveChangesAsync();

        // Create PayPal order request
        var request = new OrdersCreateRequest();
        request.Prefer("return=representation");
        request.RequestBody(new OrderRequest()
        {
            CheckoutPaymentIntent = "CAPTURE",
            PurchaseUnits = new List<PurchaseUnitRequest>
            {
                new PurchaseUnitRequest
                {
                    AmountWithBreakdown = new AmountWithBreakdown
                    {
                        CurrencyCode = "USD",
                        // Format with invariant culture to ensure dot decimal separator
                        Value = totalAmount.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)
                    }
                }
            },
            ApplicationContext = new ApplicationContext
            {
                // Point to this controller's Return/Cancel actions
                ReturnUrl = Url.Action("Return", "Home", new { paymentId = payment.Id }, Request.Scheme),
                CancelUrl = Url.Action("Cancel", "Home", new { paymentId = payment.Id }, Request.Scheme)
            }
        });

        // Execute request and get PayPal SDK Order type explicitly
        var response = await _payPalClient.Execute(request);
        var paypalOrder = response.Result<PayPalCheckoutSdk.Orders.Order>();

        // Find approval URL
        var approveUrl = paypalOrder?.Links?.FirstOrDefault(l => string.Equals(l.Rel, "approve", StringComparison.OrdinalIgnoreCase))?.Href;

        if (string.IsNullOrEmpty(approveUrl))
        {
            // mark payment failed and persist
            payment.Status = "Failed";
            payment.UpdatedAt = DateTime.Now;
            await commerceContext.SaveChangesAsync();
            return BadRequest("Unable to create PayPal approval link.");
        }

        return Redirect(approveUrl);
    }

    // GET: Return بعد الدفع
    public async Task<IActionResult> Return(int paymentId, string token, string PayerID)
    {
        // Load payment and related order
        var payment = commerceContext.Payments
            .Include(p => p.Order)
            .FirstOrDefault(p => p.Id == paymentId);

        if (payment == null)
            return NotFound();

        // Prepare capture request for PayPal order (token is the PayPal order id)
        var request = new OrdersCaptureRequest(token);
        request.RequestBody(new OrderActionRequest());

        // Execute via injected PayPal client asynchronously
        var response = await _payPalClient.Execute(request);

        // Use the PayPal SDK Order type explicitly to avoid conflicts with local Order model alias
        var result = response.Result<PayPalCheckoutSdk.Orders.Order>();

        if (result != null && string.Equals(result.Status, "COMPLETED", StringComparison.OrdinalIgnoreCase))
        {
            payment.Status = "Completed";
            payment.ProviderPaymentId = result.Id;
            payment.RawResponse = Newtonsoft.Json.JsonConvert.SerializeObject(result);

            if (payment.Order != null)
            {
                payment.Order.Onlinepaid = true;
            }
        }
        else
        {
            payment.Status = "Failed";
        }

        payment.UpdatedAt = DateTime.Now;

        await commerceContext.SaveChangesAsync();

        if (string.Equals(payment.Status, "Completed", StringComparison.OrdinalIgnoreCase))
            return RedirectToAction("Success1", "Home", new { id = payment.OrderId });
        else
            return RedirectToAction("Failed", "Home", new { id = payment.OrderId });
    }

    // GET: Cancel
    public IActionResult Cancel(int paymentId)
    {
        var payment = commerceContext.Payments.FirstOrDefault(p => p.Id == paymentId);
        if (payment != null)
        {
            payment.Status = "Canceled";
            payment.UpdatedAt = DateTime.Now;
          commerceContext.SaveChanges();
        }
        return RedirectToAction("Failed", "Home", new { id = payment?.OrderId ?? 0 });
    }
    [HttpPost]
    public async Task<IActionResult> UpdateCartItemQuantity(int productId, int quantity)
    {
        if (quantity <= 0)
        {
            return BadRequest("Invalid quantity.");
        }

        // Convert User.Identity.Name to int for comparison
        
        var cartItem = await commerceContext.Carts
            .FirstOrDefaultAsync(c => c.Productid == productId && c.Userid == User.Identity.Name);

        if (cartItem == null)
        {
            return NotFound();
        }

        // ✅ عدل الكمية
        cartItem.Quntity = quantity;

        // ✅ عدل التوتال (اختياري لو مخزّنة في الجدول)

        await commerceContext.SaveChangesAsync();

        return RedirectToAction(nameof(Cart)); // يرجع يعرض الكارت بعد التعديل
    }
    public IActionResult Failed(int id)
    {
        // id هنا ممكن تستخدمه لعرض الطلب اللي فشل الدفع له
        var order =commerceContext.Orders.Find(id);
        if (order == null) return NotFound();

        return View(order); // لازم يكون عندك View باسم Failed.cshtml
    }

}
