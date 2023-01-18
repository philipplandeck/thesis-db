using System.ComponentModel.DataAnnotations;

namespace ThesisDatenbank.Models
{
    public class Chair
    {
        public int Id { get; set; }

        [Display(Name = "Lehrstuhl")]
        public string Name { get; set; }

        public ICollection<Supervisor> Supervisors { get; set; }
    }
}
