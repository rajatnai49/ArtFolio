﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace artfolio.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
    }
}