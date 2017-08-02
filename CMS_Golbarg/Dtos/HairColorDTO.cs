using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.Dtos
{
    public class HairColorDto
    {
        public int Id { get; set; }
        
        public string InterNationalColorCode { get; set; }
        public string InterNationalColorName { get; set; }

    }
}