using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required, StringLength(500)]
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
