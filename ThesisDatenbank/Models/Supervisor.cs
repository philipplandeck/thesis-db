using System.ComponentModel.DataAnnotations;

namespace ThesisDatenbank.Models
{
    public class Supervisor
    {
        public int Id { get; set; }

        [Display(Name = "Vorname")]
        public string FirstName { get; set; }

        [Display(Name = "Nachname")]
        public string LastName { get; set; }

        [Display(Name = "Aktiver Mitarbeiter?")]
        public bool Active { get; set; }

        [Display(Name = "Lehrstuhl")]
        public Chair Chair { get; set; }
    }
}
