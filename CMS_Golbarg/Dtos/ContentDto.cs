using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.Dtos
{
    public class ContentDto
    {

        
        public int? ID { set; get; }

        
        [StringLength(100)]
        public string Title { set; get; }

        
        [StringLength(300)]
        public string Summury_Content { set; get; }

        
        public string Full_Content { set; get; }

       
        public DateTime? Date_Register { set; get; }

        
        public DateTime? Date_Publish { set; get; }

        
        
    }
}