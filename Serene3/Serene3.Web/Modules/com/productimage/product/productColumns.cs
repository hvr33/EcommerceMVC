using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace Serene3.com.Columns;

[ColumnsScript("com.product")]
[BasedOnRow(typeof(productRow), CheckNames = true)]
public class productColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int Id { get; set; }
    [EditLink]
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string CeitoName { get; set; }
    public string Photo { get; set; }
    public string Type { get; set; }
    public string Siplername { get; set; }
    public DateOnly Entitydata { get; set; }
    public string Reviewurl { get; set; }
    public string Productquntity { get; set; }
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
}