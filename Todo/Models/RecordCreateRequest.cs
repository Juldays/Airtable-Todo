using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Todo.Models
{
    public class RecordCreateRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Priority { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}