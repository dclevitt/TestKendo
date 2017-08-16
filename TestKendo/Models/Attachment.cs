using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestKendo.Models
{
    public class Attachment
    {
        public string Description { get; set; }
        public bool IsDefaultImage { get; set; }
        public DateTime DateAdded { get; set; }
        public byte[] Bytes { get; set; }
    }
}