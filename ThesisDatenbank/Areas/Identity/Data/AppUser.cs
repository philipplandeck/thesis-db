﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using ThesisDatenbank.Models;

namespace ThesisDatenbank.Areas.Identity.Data;

public class AppUser : IdentityUser
{
    public enum ActivityType
    {
        [Display(Name = "Aktiv")]
        active,

        [Display(Name = "Inaktiv")]
        inactive
    }

    [Required]
    [Display(Name = "Vorname")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Nachname")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Aktivitätsstatus")]
    public ActivityType Activity { get; set; } = ActivityType.active;

    [ForeignKey("Chair")]
    public int? ChairId { get; set; }

    [Display(Name = "Lehrstuhl")]
    public virtual Chair? Chair { get; set; }
}
