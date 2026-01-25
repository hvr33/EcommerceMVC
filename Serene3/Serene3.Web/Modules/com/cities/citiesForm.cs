using Serenity.ComponentModel;

namespace Serene3.com.Forms;

[FormScript("com.cities")]
[BasedOnRow(typeof(citiesRow), CheckNames = true)]
public class citiesForm
{
    public string Name { get; set; }
    public int StateId { get; set; }
}