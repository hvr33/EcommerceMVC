using Serenity.ComponentModel;

namespace Serene3.com.Forms;

[FormScript("com.review")]
[BasedOnRow(typeof(reviewRow), CheckNames = true)]
public class reviewForm
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
}