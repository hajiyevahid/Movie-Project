using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Models
{
    public class Genre
    {   
        public int Id { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "Genre of the movie")]
        public string? GenreName { get; set; }
    }
}