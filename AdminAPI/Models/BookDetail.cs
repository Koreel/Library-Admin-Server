using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
    namespace AdminAPI.Models
{
    public class BookDetail  
    {
        [Key]
        public int Id { get; set; }
        [Column(name:"title", TypeName = "varchar(50)")]
        public string Title { get; set; }  = string.Empty;
        [Column(name:"author", TypeName = "varchar(100)")]
        public string Author { get; set; }  = string.Empty;
        [Column(name:"blurb", TypeName = "varchar(max)")]
        public string? Blurb { get; set; } = string.Empty;
        [Column(name:"year_published")]
        public int YearPublished { get; set; }
        [Column(name:"book_copies")]
        public int bookCopies { get; set; }
    }  
}

