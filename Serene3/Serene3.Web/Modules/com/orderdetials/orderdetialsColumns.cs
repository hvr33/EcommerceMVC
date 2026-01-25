using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace Serene3.com.Columns;

[ColumnsScript("com.orderdetials")]
[BasedOnRow(typeof(orderdetialsRow), CheckNames = true)]
public class orderdetialsColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int Id { get; set; }
    public string ProductidName { get; set; }
    public decimal Totalprice { get; set; }
    public int Quantity { get; set; }
    public string OrderidUserid { get; set; }
    public decimal Price { get; set; }
    public DateOnly Entitydata { get; set; }
}