using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSIApiWebApp.Core
{
    public class UploadedImage
    {
        public int Id { get; set; }
        [Required, StringLength(1000)]
        public string Name{get;set;}
        [Required]
        public double Size { get; set; }
        [Required, StringLength(10)]
        public string Format { get; set; }
    }
}
