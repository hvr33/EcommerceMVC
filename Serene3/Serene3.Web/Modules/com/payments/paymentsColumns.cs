using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace Serene3.com.Columns;

[ColumnsScript("com.payments")]
[BasedOnRow(typeof(paymentsRow), CheckNames = true)]
public class paymentsColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int Id { get; set; }
    public string OrderUserid { get; set; }
    [EditLink]
    public string Provider { get; set; }
    public string ProviderPaymentId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string Status { get; set; }
    public string RawResponse { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}