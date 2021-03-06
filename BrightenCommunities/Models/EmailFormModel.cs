﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrightenCommunities.Models
{
    public class EmailFormModel
    {

        [Required, Display(Name = "Name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Email")]
        public string FromEmail { get; set; }
        [Required]
        public string Message { get; set; }
       
    }
}