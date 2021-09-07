using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBlog.Models.Models
{
    public class Blog
    {   
        [Key]
        public int BlogId { get; set; }

        [Required]
        public string BlogTitle { get; set; }

        [Required]
        public string BlogContent { get; set; }
    }
}
