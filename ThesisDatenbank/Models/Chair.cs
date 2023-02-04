using System.ComponentModel.DataAnnotations;
using ThesisDatenbank.Areas.Identity.Data;

namespace ThesisDatenbank.Models
{
    public class Chair
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Für den Lehrstuhl muss ein Name angegeben werden.")]
        [Display(Name = "Lehrstuhl")]
        public string Name { get; set; }

        public virtual ICollection<Supervisor>? Supervisors { get; set; }

        public virtual ICollection<AppUser>? Users { get; set; }
    }
}
