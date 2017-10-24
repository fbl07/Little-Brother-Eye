using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LittleBrotherEye.Models
{
    public class APIRegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool confirmation { get; set; }
    }
}