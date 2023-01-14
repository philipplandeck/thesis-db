using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using ThesisDatenbank.Models;

namespace ThesisDatenbank.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    /*public enum ActivityType
    {
        active,
        inactive
    }

    [Required]
    [MinLength(2, ErrorMessage = "Die Eingabe muss mindestens zwei Zeichen lang sein.")]
    [Display(Name = "Vorname")]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Die Eingabe muss mindestens zwei Zeichen lang sein.")]
    [Display(Name = "Nachname")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Lehrstuhl")]
    public Chair Chair { get; set; }

    [Required]
    [Display(Name = "Aktivitätsstatus")]
    public ActivityType Activity { get; set; }*/
}
