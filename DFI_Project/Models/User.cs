using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic.CompilerServices;

namespace DFI_Project.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be more than 5 characters and less than 20 characters")]
        [Display(Name = "Username")]
        public string UserUsername { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string UserEmail { get; set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        [Required]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Hometown")]
        public string UserHometown { get; set; }

        [Required]
        [Display(Name = "BirthDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UserBirthDate { get; set; }

        [Required]
        [Display(Name = "Twitter")]
        public string UserTwitter { get; set; }

        [Required]
        [Display(Name = "Instagram")]
        public string UserInstagram { get; set; }

    }
}
