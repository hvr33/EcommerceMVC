using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene3.com.Pages;

[PageAuthorize(typeof(cartRow))]
public class cartPage : Controller
{
    [Route("com/cart")]
    public ActionResult Index()
    {
        return this.GridPage<cartRow>("@/com/cart/cartPage");
    }
}