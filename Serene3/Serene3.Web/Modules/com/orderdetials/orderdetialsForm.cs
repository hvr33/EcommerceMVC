using Serenity.ComponentModel;
using System;

namespace Serene3.com.Forms;

[FormScript("com.orderdetials")]
[BasedOnRow(typeof(orderdetialsRow), CheckNames = true)]
public class orderdetialsForm
{
    public int Productid { get; set; }
    public decimal Totalprice { get; set; }
    public int Quantity { get; set; }
    public int Orderid { get; set; }
    public decimal Price { get; set; }
    public DateOnly Entitydata { get; set; }
}