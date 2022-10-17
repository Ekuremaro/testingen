using System;
using testingen.Models;
namespace testingen.ViewModel
{
    public class NewMovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}

