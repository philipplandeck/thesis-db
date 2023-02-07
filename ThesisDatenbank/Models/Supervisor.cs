using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThesisDatenbank.Areas.Identity.Data;

namespace ThesisDatenbank.Models
{
    public class Supervisor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Vorname")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nachname")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-Mail-Adresse")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Aktiver Mitarbeiter?")]
        public bool Active { get; set; }

        [ForeignKey("Chair")]
        public int? ChairId { get; set; }

        [Display(Name = "Lehrstuhl")]
        public virtual Chair? Chair { get; set; }

        [ForeignKey("AppUser")]
        public string? UserId { get; set; }

        [Display(Name = "Nutzer")]
        public virtual AppUser? User { get; set; }

        public virtual ICollection<Thesis>? Theses { get; set; }
    }
}
