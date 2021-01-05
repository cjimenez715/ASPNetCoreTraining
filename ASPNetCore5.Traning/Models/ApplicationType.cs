using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore5.Traning.Models
{
    public class ApplicationType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string ApplicationTypeName { get; set; }
    }
}
