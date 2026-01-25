using Serenity.ComponentModel;
using System;

namespace Serene3.com.Forms;

[FormScript("com.order")]
[BasedOnRow(typeof(orderRow), CheckNames = true)]
public class orderForm
{
    public string Userid { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public bool Onlinepaid { get; set; }
    public DateOnly EntityDate { get; set; }
    public string CustomerName { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public int CityId { get; set; }
    public string Address { get; set; }
    public DateTime OrderDate { get; set; }
    public int Productid { get; set; }
}