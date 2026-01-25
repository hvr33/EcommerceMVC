using Serenity.ComponentModel;
using System;

namespace Serene3.com.Forms;

[FormScript("com.payments")]
[BasedOnRow(typeof(paymentsRow), CheckNames = true)]
public class paymentsForm
{
    public int OrderId { get; set; }
    public string Provider { get; set; }
    public string ProviderPaymentId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string Status { get; set; }
    public string RawResponse { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}