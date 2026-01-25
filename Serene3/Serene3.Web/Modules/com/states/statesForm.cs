using Serenity.ComponentModel;

namespace Serene3.com.Forms;

[FormScript("com.states")]
[BasedOnRow(typeof(statesRow), CheckNames = true)]
public class statesForm
{
    public string Name { get; set; }
    public int CountryId { get; set; }
}