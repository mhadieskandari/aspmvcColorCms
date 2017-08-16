using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Golbarg.Core.Models
{
    public class Setting
    {
        [Key]
        public int id { set; get; }

        [Display(Name="نام تنظیمات")]
        public string Setting_Name { set; get; }

        [Display(Name = "مقدار تنظیمات")]
        public string Setting_Value { set; get; }


        [NotMapped]
        public const string TRNSACTION_FI = "TRNSACTION_FI";

        [NotMapped]
        public const string SHOWDAYS_NO = "SHOWDAYS_NO";


    }
}