using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marthaLibrary.Models.DTOs
{
    public class BookDto
    {
        public long Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string BookStatus { get; set; }
        public string FrontPagePicUrl { get; set; }
    }
}
