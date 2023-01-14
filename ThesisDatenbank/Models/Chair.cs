using System.ComponentModel.DataAnnotations;

namespace ThesisDatenbank.Models
{
    public class Chair
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Lehrstuhl")]
        public string Name { get; set; }
    }
}
