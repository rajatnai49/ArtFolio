using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace artfolio.Models
{
    public class Customization
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string Font { get; set; }
    }
}