using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
                    
namespace MyLibraryDotNet472.Models
{
    public class BFormat
    {
        [Key]
       public int Id { get; set; }

        [Display(Name = "Book format")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Formate type should be minimum 3 characters and a maximum of 100 characters")]
        public string FormatType { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}