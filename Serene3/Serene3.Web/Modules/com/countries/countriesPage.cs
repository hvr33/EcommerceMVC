using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Serene3.com.Pages;

[PageAuthorize(typeof(countriesRow))]
public class countriesPage : Controller
{
    [Route("com/countries")]
    public ActionResult Index()
    {
        return this.GridPage<countriesRow>("@/com/countries/countriesPage");
    }
}