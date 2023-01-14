using System.ComponentModel;
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
        [MinLength(2, ErrorMessage = "Die Eingabe muss mindestens zwei Zeichen lang sein.")]
        [Display(Name = "Titel der Thesis")]
        public string Title { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Die Eingabe muss mindestens zwei Zeichen lang sein.")]
        [Display(Name = "Aufgabenstellung")] // ToDo: Nachfragen ob Description == Thesis
        public string Description { get; set; }

        [Display(Name = "Thema ist für die Bearbeitung als Bachelor Thesis geeignet")]
        public bool Bachelor { get; set; }

        [Display(Name = "Thema ist für die Bearbeitung als Master Thesis geeignet")]
        public bool Master { get; set; }

        [Required]
        [Display(Name = "Status der Thesis")]
        public StatusType Status { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Die Eingabe muss mindestens zwei Zeichen lang sein.")]
        [Display(Name = "Name des Studenten")]
        public string StudentName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-Mail-Adresse des Studenten")]
        public string StudentEMail { get; set; }

        [Required]
        [MinLength(7, ErrorMessage = "Die Matrikelnummer muss genau 7 Ziffern enthalten.")]
        [MaxLength(7, ErrorMessage = "Die Matrikelnummer muss genau 7 Ziffern enthalten.")]
        [Display(Name = "Matrikelnummer des Studenten")]
        public string StudentId { get; set; }

        [Display(Name = "Studiengang des Studenten")]
        public Program StudentProgram { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Anmeldedatum der Thesis")]
        public DateTime Registration { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Abgabedatum der Thesis")]
        public DateTime Filing { get; set; }

        [Display(Name = "Zusammenfassung der Thesis")]
        public string Summary { get; set; }

        [Display(Name = "Stärken der Thesis")]
        public string Strengths { get; set; }

        [Display(Name = "Schwächen der Thesis")]
        public string Weaknesses { get; set; }

        [Display(Name = "Bewertung der Thesis")]
        public string Evaluation { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung des Inhalts")]
        public int ContentVal { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung des Layouts")]
        public int LayoutVal { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung der Struktur")]
        public int StructureVal { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung des Stils")]
        public int StyleVal { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung der Literatur")]
        public int LiteratureVal { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung der Schwierigkeit")]
        public int DifficultyVal { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung der Neuheit")]
        public int NoveltyVal { get; set; }

        [Range(1, 5)]
        [Display(Name = "Bewertung der Reichhaltigkeit")]
        public int RichnessVal { get; set; }

        [Range(0,100)]
        [DefaultValue(30)]
        [Display(Name = "Gewichtung des Inhalts")]
        public int ContentWt { get; set; }

        [Range(0, 100)]
        [DefaultValue(15)]
        [Display(Name = "Gewichtung des Layouts")]
        public int LayoutWt { get; set; }

        [Range(0, 100)]
        [DefaultValue(10)]
        [Display(Name = "Gewichtung der Struktur")]
        public int StructureWt { get; set; }

        [Range(0, 100)]
        [DefaultValue(10)]
        [Display(Name = "Gewichtung des Stils")]
        public int StyleWt { get; set; }

        [Range(0, 100)]
        [DefaultValue(10)]
        [Display(Name = "Gewichtung der Literatur")]
        public int LiteratureWt { get; set; }

        [Range(0, 100)]
        [DefaultValue(5)]
        [Display(Name = "Gewichtung der Schwierigkeit")]
        public int DifficultyWt { get; set; }

        [Range(0, 100)]
        [DefaultValue(10)]
        [Display(Name = "Gewichtung der Neuheit")]
        public int NoveltyWt { get; set; }

        [Range(0, 100)]
        [DefaultValue(10)]
        [Display(Name = "Gewichtung der Reichhaltigkeit")]
        public int RichnessWt { get; set; }

        [Range(1, 5)]
        [Display(Name = "Note 1,0 – 5,0")] // Wieso int aber double Wert?
        public int Grade { get; set; }

        public DateTime LastModified { get; set; }

        [Display(Name = "Lehrstuhl an dem die Thesis geschrieben wird")]
        public Chair Chair { get; set; }

        [Display(Name = "Betreuer der Thesis")]
        public Supervisor Supervisor { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Bachelor == false && Master == false)
                results.Add(new ValidationResult("Bachelor oder Master muss ausgewählt werden."));

            if (ContentWt + LayoutWt + StructureWt + StyleWt + LiteratureWt + DifficultyWt + NoveltyWt + RichnessWt != 100)
                results.Add(new ValidationResult("Die Summe aller Gewichtungsfaktoren muss 100% ergeben."));

            if (Status == StatusType.Graded && Grade == 0)
                results.Add(new ValidationResult("Fehlende Note trotz begutachteter Thesis."));

            return results;
        }
    }
}
