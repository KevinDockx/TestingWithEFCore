using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.API.Entities
{
    [Table("Course")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
