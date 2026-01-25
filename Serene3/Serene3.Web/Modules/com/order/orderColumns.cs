using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace Serene3.com.Columns;

[ColumnsScript("com.order")]
[BasedOnRow(typeof(orderRow), CheckNames = true)]
public class orderColumns
{
    [EditLink]
    public string Userid { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
 
    public bool Onlinepaid { get; set; }
    public DateOnly EntityDate { get; set; }
    public string CustomerName { get; set; }
    public string CountryName { get; set; }
    public string StateName { get; set; }
    public string CityName { get; set; }
    public string Address { get; set; }
    public DateTime OrderDate { get; set; }
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int Id { get; set; }
    public int Productid { get; set; }
}