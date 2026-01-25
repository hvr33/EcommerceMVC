using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene3.com.Pages;

[PageAuthorize(typeof(productimageRow))]
public class productimagePage : Controller
{
    [Route("com/productimage")]
    public ActionResult Index()
    {
        return this.GridPage<productimageRow>("@/com/productimage/productimagePage");
    }
}