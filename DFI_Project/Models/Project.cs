using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic.CompilerServices;

namespace DFI_Project.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string ProjectTitle { get; set; }

        [Required]
        [Display(Name = "Theme")]
        public string ProjectTheme { get; set; }

        [Required]
        [Display(Name = "Registration Start")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProjectRegistStart { get; set; }

        [Required]
        [Display(Name = "Registration End")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProjectRegistEnd { get; set; }

        [Required]
        [Display(Name = "Deadline")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProjectDeadline { get; set; }

        [Required]
        [Display(Name = "Post Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProjectPostDate { get; set; }

        [Required]
        [Display(Name = "Color Palette")]
        public string ProjectColorPalette { get; set; }

        [Required]
        [Display(Name = "Canvas Size")]
        public string ProjectCanvasSize { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string ProjectDescription { get; set; }
    }
}
