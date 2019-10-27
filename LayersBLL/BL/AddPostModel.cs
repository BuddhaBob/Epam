using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayersDLL.BL
{
    public class AddPostModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, write a title")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Title's length must bee at least 1 chartchers maximum of 30")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, fill the note field")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Text's length must bee at least 10 chartchers maximum of 1000")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public int Rating { get; set; }

        
        public int CreatorId { get; set; }
    }
}



