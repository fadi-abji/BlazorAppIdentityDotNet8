using Microsoft.AspNetCore.Identity;
using System;

namespace BlazorAppIdentityDotNet8.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateOnly? DateOfBirth { get; set; }
    }

}
