using Serenity.ComponentModel;

namespace Serene3.com.Forms;

[FormScript("com.productimage")]
[BasedOnRow(typeof(productimageRow), CheckNames = true)]
public class productimageForm
{
    public int Productid { get; set; }
    public string Image { get; set; }
}