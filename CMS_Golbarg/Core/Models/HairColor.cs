using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Golbarg.Core.Models
{
    public class HairColor
    {
        [Key]
        public int Id { get; set; }

        [StringLength(5, ErrorMessage = "کد رنگ حداکثر 5  کاراکتر میباشد")]
        [Display(Name = "کد بین المللی")]
        public string InterNationalColorCode { get; set; }

        [Display(Name = "نام بین المللی")]
        public string InterNationalColorName { get; set; }

        [Display(Name = "کد فارسی")]
        [StringLength(5, ErrorMessage = "کد رنگ حداکثر 5  کاراکتر میباشد")]
        public string PersianColorCode { set; get; }

        [Display(Name = "نام فارسی")]
        public string PersianColorName { set; get; }

        [Display(Name = "عکس مو")]
        public byte[] HairPic { get; set; }


        [InverseProperty("ActualHairColor")]
        public virtual ICollection<Mixer> ActualHairColor { get; set; }

        [InverseProperty("DestinationHairColor")]
        public virtual ICollection<Mixer> DestinationHairColor { get; set; }


        public string getInfoInternational
        {
            get
            {
                return InterNationalColorName + " " + InterNationalColorCode;
            }
        }

        public string getInfoPersian
        {
            get
            {
                return PersianColorName + " " + PersianColorCode;
            }
        }

        public string FullInfo
        {
            get
            {
                return InterNationalColorName + " " + InterNationalColorCode + " " + PersianColorName;
            }
        }

        public int CodeBase1
        {
            get
            {
                try
                {
                    var dot = InterNationalColorCode.IndexOf('.');
                    if (dot == -1)
                    {
                        dot= InterNationalColorCode.IndexOf('/');
                    }
                    var cb = InterNationalColorCode.Substring(0,dot);

                    return int.Parse(cb);

                }
                catch
                {
                    return 0;
                }

            }
        }     

        public int CodeDetail1
        {
            get
            {
                try
                {
                    var dot = InterNationalColorCode.IndexOf('.');
                    if (dot == -1)
                    {
                        dot = InterNationalColorCode.IndexOf('/');
                    }
                    var cd = InterNationalColorCode.Substring(dot+1);
                    return int.Parse(cd);
                }
                catch
                {
                    return 0;
                }

            }
        }
    }
}