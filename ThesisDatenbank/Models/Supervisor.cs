using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Display(Name = "Aktiver Mitarbeiter?")]
        public bool Active { get; set; }

        [ForeignKey("Chair")]
        public int? ChairId { get; set; }

        [Display(Name = "Lehrstuhl")]
        public Chair? Chair { get; set; }
    }
}
