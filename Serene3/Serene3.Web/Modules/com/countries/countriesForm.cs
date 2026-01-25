using Serenity.ComponentModel;

namespace Serene3.com.Forms;

[FormScript("com.countries")]
[BasedOnRow(typeof(countriesRow), CheckNames = true)]
public class countriesForm
{
    public string Name { get; set; }
}