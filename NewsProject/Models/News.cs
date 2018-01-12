using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsProject.Models
{
    public class News
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string  ImageUrl { get; set; }
        public string Title { get; set; }
        public string  ClickUrl { get; set; }
    }
}