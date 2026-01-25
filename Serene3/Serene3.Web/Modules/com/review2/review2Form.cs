using Serenity.ComponentModel;
using System;

namespace Serene3.com.Forms;

[FormScript("com.review2")]
[BasedOnRow(typeof(review2Row), CheckNames = true)]
public class review2Form
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
}