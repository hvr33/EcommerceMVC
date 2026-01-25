using Serenity.ComponentModel;
using System.ComponentModel;

namespace Serene3.com.Columns;

[ColumnsScript("com.cart")]
[BasedOnRow(typeof(cartRow), CheckNames = true)]
public class cartColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int Id { get; set; }
    public string ProductidName { get; set; }
    [EditLink]
    public string Userid { get; set; }
    public string Photo { get; set; }
    public decimal Price { get; set; }
    public int Quntity { get; set; }
}