using Serenity.ComponentModel;
using System.ComponentModel;

namespace Serene3.com.Columns;

[ColumnsScript("com.countries")]
[BasedOnRow(typeof(countriesRow), CheckNames = true)]
public class countriesColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int Id { get; set; }
    [EditLink]
    public string Name { get; set; }
}