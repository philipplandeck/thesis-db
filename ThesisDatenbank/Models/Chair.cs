using System.ComponentModel.DataAnnotations;
using ThesisDatenbank.Areas.Identity.Data;

namespace ThesisDatenbank.Models
{
    public class Chair
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Lehrstuhl")]
        public string Name { get; set; }

        public List<Supervisor>? Supervisors { get; set; }

        public List<AppUser>? Users { get; set; }
    }
}
