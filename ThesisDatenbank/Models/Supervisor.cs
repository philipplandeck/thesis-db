using System.ComponentModel.DataAnnotations;

namespace ThesisDatenbank.Models
{
    public class Supervisor
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Die Eingabe muss mindestens zwei Zeichen lang sein.")]
        [Display(Name = "Vorname")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Die Eingabe muss mindestens zwei Zeichen lang sein.")]
        [Display(Name = "Nachname")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Aktivitätsstatus")]
        public bool Active { get; set; }
    }
}
