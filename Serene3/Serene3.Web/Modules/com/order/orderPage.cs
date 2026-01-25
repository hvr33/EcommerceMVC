using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene3.com.Pages;

[PageAuthorize(typeof(orderRow))]
public class orderPage : Controller
{
    [Route("com/order")]
    public ActionResult Index()
    {
        return this.GridPage<orderRow>("@/com/order/orderPage");
    }
}