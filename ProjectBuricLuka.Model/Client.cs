﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBuricLuka.Model
{
    public class Client
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Unesite barem 3 znaka")]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";

        [Required]
        public string Email { get; set; } = "";

        public DateTime? DateOfBirth { get; set; }

        [Range(1, 100)]
        public int? WorkingExperience { get; set; }
        public char Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        [ForeignKey(nameof(City))]
        public int? CityID { get; set; }
        public City? City { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public virtual ICollection<Meeting>? Meetings { get; set; }
        public string? UpdatedById { get; set; }
        public string? CreatedById { get; set; }

    }
}
