using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Models
{
    public class Movie
    {   
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string? Title { get; set; }

        [DataType(DataType.MultilineText)]
        [BindProperty]
        [Display(Name = "Long description")]
        public string? LongDescription { get; set; }

        [Display(Name = "Main cast")]
        public string? MainCast{ get; set; }


        [Display(Name = "Director")]
        public string? Director { get; set; }


        //[DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release date")]
        public DateOnly ReleaseDate { get; set; }

        [Display(Name = "Genre of the movie")]
        public int? GenreId { get; set; }
    }
}