﻿using System;
using System.ComponentModel.DataAnnotations;

namespace testingen.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }


        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }


        public Genre Genre { get; set; }

        //[Required(ErrorMessage = "The genre Field is required")]
        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

    }
}

