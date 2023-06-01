using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYM4UApp.Models
{
    public class ActivityEditView
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; }  
    }
}