using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene3.com.Pages;

[PageAuthorize(typeof(cetogeryRow))]
public class cetogeryPage : Controller
{
    [Route("com/cetogery")]
    public ActionResult Index()
    {
        return this.GridPage<cetogeryRow>("@/com/cetogery/cetogeryPage");
    }
}