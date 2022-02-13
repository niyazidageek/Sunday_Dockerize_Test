using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Models
{
    public class Book:IEntity
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required, StringLength(500)]
        public string Description { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.UtcNow;
    }
}
