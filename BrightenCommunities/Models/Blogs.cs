using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace BrightenCommunities.Models
{
    public class Blogs
    {   
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Post { get; set; }
    }    
}