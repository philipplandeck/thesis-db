using System.ComponentModel.DataAnnotations;

namespace ThesisDatenbank.Models
{
    public class Supervisor
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Vorname")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nachname")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Aktiver Mitarbeiter?")]
        public bool Active { get; set; }
    }
}
