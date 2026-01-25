using Serenity.ComponentModel;

namespace Serene3.com.Forms;

[FormScript("com.cart")]
[BasedOnRow(typeof(cartRow), CheckNames = true)]
public class cartForm
{
    public int Productid { get; set; }
    public string Userid { get; set; }
    public string Photo { get; set; }
    public decimal Price { get; set; }
    public int Quntity { get; set; }
}