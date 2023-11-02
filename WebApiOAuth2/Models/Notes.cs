using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiOAuth2.Models
{
    public class Notes
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string NotesTitle { get; set; }

        [StringLength(1000)]
        public string NotesDescription { get; set; }

        public string UserId { get; set; }
    }
}