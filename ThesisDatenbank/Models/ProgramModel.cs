using System.ComponentModel.DataAnnotations;

namespace ThesisDatenbank.Models
{
    public class ProgramModel
    {
        public enum ProgramType
        {
            [Display(Name = "Bachelor Wirtschaftsinformatik")]
            BAWIINFO,

            [Display(Name = "Bachelor Wirtschaftswissenschaften")]
            BAWIWI,

            [Display(Name = "Master Business Management")]
            MBM,

            [Display(Name = "Master Information Systems")]
            MIS
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Studiengang")]
        public ProgramType Name { get; set; }
    }
}
