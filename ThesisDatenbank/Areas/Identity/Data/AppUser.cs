using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using ThesisDatenbank.Models;

namespace ThesisDatenbank.Areas.Identity.Data;

public class AppUser : IdentityUser
{
    public enum ActivityType
    {
        active,
        inactive
    }

    [Display(Name = "Vorname")]
    public string? FirstName { get; set; }

    [Display(Name = "Nachname")]
    public string? LastName { get; set; }

    [Display(Name = "Lehrstuhl")]
    public Chair? Chair { get; set; }

    [Display(Name = "Aktivitätsstatus")]
    public ActivityType? Activity { get; set; }
}
