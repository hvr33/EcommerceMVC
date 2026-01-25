using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace E_COMMERCE.Areas.Identity.Data;

// Add profile data for application users by adding properties to the E_COMMERCEUser class
public class E_COMMERCEUser : IdentityUser
{

    [PersonalData]
    public string? Name { get; set; }
    [PersonalData]
    public DateTime DOB { get; set; }
}

