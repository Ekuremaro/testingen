using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using testingen.Models;

namespace testingen.ViewModel
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public byte? NumberInStock { get; set; }

        [Required(ErrorMessage = "The genre Field is required")]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0) return "Edit Movie";

                return "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}

