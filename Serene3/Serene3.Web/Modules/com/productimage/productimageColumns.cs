using Serenity.ComponentModel;
using System.ComponentModel;

namespace Serene3.com.Columns;

[ColumnsScript("com.productimage")]
[BasedOnRow(typeof(productimageRow), CheckNames = true)]
public class productimageColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int Id { get; set; }
    public string ProductidName { get; set; }
    [EditLink]
    public string Image { get; set; }
}