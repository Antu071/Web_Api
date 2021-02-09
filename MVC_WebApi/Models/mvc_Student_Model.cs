using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_WebApi.Models
{
    public class mvc_Student_Model
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public string Student_name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}