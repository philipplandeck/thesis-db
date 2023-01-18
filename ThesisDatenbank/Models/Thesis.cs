using System.ComponentModel.DataAnnotations;

namespace ThesisDatenbank.Models
{
    public class Thesis : IValidatableObject
    {
        public enum StatusType
        {
            [Display(Name = "Frei")]
            Available,

            [Display(Name = "Reserviert")]
            Allocated,

            [Display(Name = "In Bearbeitung")]
            Filed,

            [Display(Name = "Abgegeben")]
            Submitted,

            [Display(Name = "Begutachtet")]
            Graded
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Titel")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Themenbeschreibung / Aufgabenstellung")]
        public string Description { get; set; }

        [Display(Name = "Thema ist für die Bearbeitung als Bachelor Thesis geeignet")]
        public bool Bachelor { get; set; }

        [Display(Name = "Thema ist für die Bearbeitung als Master Thesis geeignet")]
        public bool Master { get; set; }

        [Display(Name = "Status")]
        public StatusType Status { get; set; }

        [Display(Name = "Name des Studenten")]
        public string? StudentName { get; set; }

        [EmailAddress]
        [Display(Name = "E-Mail-Adresse des Studenten")]
        public string? StudentEMail { get; set; }

        [MinLength(7, ErrorMessage = "Die Matrikelnummer muss genau 7 Ziffern enthalten.")]
        [MaxLength(7, ErrorMessage = "Die Matrikelnummer muss genau 7 Ziffern enthalten.")]
        [Display(Name = "Matrikelnummer des Studenten")]
        public string? StudentId { get; set; }

        [Display(Name = "Studiengang des Studenten")]
        public ProgramModel? StudentProgram { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Anmeldedatum")]
        public DateTime? Registration { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Abgabedatum")]
        public DateTime? Filing { get; set; }

        [Display(Name = "Zusammenfassung")]
        public string? Summary { get; set; }

        [Display(Name = "Stärken")]
        public string? Strengths { get; set; }

        [Display(Name = "Schwächen")]
        public string? Weaknesses { get; set; }

        [Display(Name = "Bewertung")]
        public string? Evaluation { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung des Inhalts")]
        public int? ContentVal { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung des Layouts")]
        public int? LayoutVal { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung der Struktur")]
        public int? StructureVal { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung des Stils")]
        public int? StyleVal { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung der Literatur")]
        public int? LiteratureVal { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung der Schwierigkeit")]
        public int? DifficultyVal { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung der Neuheit")]
        public int? NoveltyVal { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung der Reichhaltigkeit")]
        public int? RichnessVal { get; set; }

        [Required]
        [Range(0, 100)]
        [Display(Name = "Gewichtung des Inhalts")]
        public int ContentWt { get; set; } = 30;

        [Required]
        [Range(0, 100)]
        [Display(Name = "Gewichtung des Layouts")]
        public int LayoutWt { get; set; } = 15;

        [Required]
        [Range(0, 100)]
        [Display(Name = "Gewichtung der Struktur")]
        public int StructureWt { get; set; } = 10;

        [Required]
        [Range(0, 100)]
        [Display(Name = "Gewichtung des Stils")]
        public int StyleWt { get; set; } = 10;

        [Required]
        [Range(0, 100)]
        [Display(Name = "Gewichtung der Literatur")]
        public int LiteratureWt { get; set; } = 10;

        [Required]
        [Range(0, 100)]
        [Display(Name = "Gewichtung der Schwierigkeit")]
        public int DifficultyWt { get; set; } = 5;

        [Required]
        [Range(0, 100)]
        [Display(Name = "Gewichtung der Neuheit")]
        public int NoveltyWt { get; set; } = 10;

        [Required]
        [Range(0, 100)]
        [Display(Name = "Gewichtung der Reichhaltigkeit")]
        public int RichnessWt { get; set; } = 10;

        [Range(1, 5)]
        [Display(Name = "Note")]
        public double? Grade { get; set; }

        [Display(Name = "Betreuer")]
        public Supervisor? Supervisor { get; set; }

        [Display(Name = "Lehrstuhl")]
        public Chair? Chair { get; set; }

        public DateTime? LastModified { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Bachelor == false && Master == false)
                results.Add(new ValidationResult("Bachelor oder Master muss ausgewählt werden."));

            var wtSum = ContentWt + LayoutWt + StructureWt + StyleWt + LiteratureWt + DifficultyWt + NoveltyWt + RichnessWt;
            if (wtSum != 100)
                results.Add(new ValidationResult("Die Summe aller Gewichtungsfaktoren muss 100% ergeben."));

            if (Status == StatusType.Graded && Grade == 0)
                results.Add(new ValidationResult("Fehlende Note trotz begutachteter Thesis."));

            return results;
        }
    }
}
