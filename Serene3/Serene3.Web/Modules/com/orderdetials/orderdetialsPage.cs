using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene3.com.Pages;

[PageAuthorize(typeof(orderdetialsRow))]
public class orderdetialsPage : Controller
{
    [Route("com/orderdetials")]
    public ActionResult Index()
    {
        return this.GridPage<orderdetialsRow>("@/com/orderdetials/orderdetialsPage");
    }
}