using Serenity.ComponentModel;

namespace Serene3.com.Forms;

[FormScript("com.cetogery")]
[BasedOnRow(typeof(cetogeryRow), CheckNames = true)]
public class cetogeryForm
{
    public string Name { get; set; }
    public string Photos { get; set; }
    public string Description { get; set; }
}