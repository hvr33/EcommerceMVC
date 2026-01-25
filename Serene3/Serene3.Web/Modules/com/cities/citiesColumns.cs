using Serenity.ComponentModel;
using System.ComponentModel;

namespace Serene3.com.Columns;

[ColumnsScript("com.cities")]
[BasedOnRow(typeof(citiesRow), CheckNames = true)]
public class citiesColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int Id { get; set; }
    [EditLink]
    public string Name { get; set; }
    public string StateName { get; set; }
}