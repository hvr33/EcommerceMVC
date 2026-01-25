using Serenity.ComponentModel;
using System.ComponentModel;

namespace Serene3.com.Columns;

[ColumnsScript("com.cetogery")]
[BasedOnRow(typeof(cetogeryRow), CheckNames = true)]
public class cetogeryColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int Id { get; set; }
    [EditLink]
    public string Name { get; set; }
    public string Photos { get; set; }
    public string Description { get; set; }
}