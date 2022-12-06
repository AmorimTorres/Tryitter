﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Rede_Social_Da_Galera___Tryitter.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string? StudentName { get; set;}
        [Required]
        [MaxLength(80)]
        public string? StudentEmail { get; set; }
        [Required]
        [MaxLength(50)]
        public string? CourseModule { get; set; }
        [MaxLength(80)]
        public string? Status { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string? Password { get; set; }
        public int AccountId { get; set; }
        [JsonIgnore]
        public Account? Account { get; set; }
    }
}