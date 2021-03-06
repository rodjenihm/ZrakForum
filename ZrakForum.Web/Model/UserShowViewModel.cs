﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ZrakForum.Web.Model
{
    public class UserShowViewModel
    {
        [Display(Name = "Vreme registracije")]
        public DateTime CreatedAt { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "Korisničko ime")]
        public string Username { get; set; }
        [Display(Name = "Email Adresa")]
        public string Email { get; set; }
        [Display(Name = "Ime")]
        public string FirstName { get; set; }
        [Display(Name = "Prezime")]
        public string LastName { get; set; }
    }
}
