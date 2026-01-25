using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace Serene3.com.Columns;

[ColumnsScript("com.review2")]
[BasedOnRow(typeof(review2Row), CheckNames = true)]
public class review2Columns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int Id { get; set; }
    public string ProductName { get; set; }
    [EditLink]
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
}