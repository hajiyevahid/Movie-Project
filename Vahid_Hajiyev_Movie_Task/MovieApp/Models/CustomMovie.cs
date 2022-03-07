using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Models
{
    public class CustomMovie
    {   
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Title")]
        public string? Title { get; set; }

        [BindProperty]
        [Display(Name = "Genre of the movie")]
        public string? Genre { get; set; }

        public int? GenreId { get; set; }

        [DataType(DataType.Date)]
        [BindProperty]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release date")]
        public DateOnly ReleaseDate { get; set; }

        [DataType(DataType.MultilineText)]
        [BindProperty]
        [Display(Name = "Long description")]
        public string? LongDescription{ get; set; }

        [BindProperty]
        [Display(Name = "Main cast")]
        public string? MainCast { get; set; }

        [BindProperty]
        [Display(Name = "Director")]
        public string? Director{ get; set; }

    }
}