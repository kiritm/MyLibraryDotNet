using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyLibraryDotNet472.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        //   [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Book {0} is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name Should be minimum 3 characters and a maximum of 100 characters")]
        public string BookTitle { get; set; }

        //[Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Edition")]
        public string BookEdition { get; set; }

        // [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Author")]
        public string BookAuthor1 { get; set; }

        //   [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Second Author")]
        public string BookAuthor2 { get; set; }

        //   [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Category")]
        public string BookCategory { get; set; }

        // [Column(TypeName = "decimal(6,2)")]
        [Display(Name = "Purchase Cost ($)")]
        [Range(0, 999999.99, ErrorMessage = "Invalid Target Price; Max 6 digits")]
        public decimal BookPurchasePrice { get; set; }

        //   [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Publisher")]
        public string BookPublisher { get; set; }

        //  [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "ISBN")]
        public string BookISBN { get; set; }

        //  [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Status")]
        public string BookStatus { get; set; }

        //   [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Code")]
        public string BookStorage_Code { get; set; }

        //  [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Format")]
        public string BookFormat { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        //Foreign Key
        [Display(Name = "Format")]
        public int BFormatId { get; set; }
        [Display(Name = "Category")]
        public int BCategoryId { get; set; }


        //Navigation property       
        public  BFormat BFormat { get; set; }
        public virtual BCategory BCategory { get; set; }
    }
}