using Serenity.ComponentModel;
using System;

namespace Serene3.com.Forms;

[FormScript("com.product")]
[BasedOnRow(typeof(productRow), CheckNames = true)]
public class productForm
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Ceito { get; set; }
    public string Photo { get; set; }
    public string Type { get; set; }
    public string Siplername { get; set; }
    public DateOnly Entitydata { get; set; }
    public string Reviewurl { get; set; }
    public string Productquntity { get; set; }
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
}