using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore5.Traning.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string CatergoryName { get; set; }
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Display Order must be greater than 0")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

    }
}
