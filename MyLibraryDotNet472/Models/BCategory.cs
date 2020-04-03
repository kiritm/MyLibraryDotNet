using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyLibraryDotNet472.Models
{
    public class BCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Book Category")]
        public string BCategoryType { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}