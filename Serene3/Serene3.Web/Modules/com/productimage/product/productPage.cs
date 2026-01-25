using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene3.com.Pages;

[PageAuthorize(typeof(productRow))]
public class productPage : Controller
{
    [Route("com/product")]
    public ActionResult Index()
    {
        return this.GridPage<productRow>("@/com/product/productPage");
    }
}