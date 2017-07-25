using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Golbarg.Areas.Admin.Models
{
    public class HairColor
    {
        [Key]
        public int Id { get; set ; }

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
                return InterNationalColorName + " " + InterNationalColorCode ;
            }
        }

        public string getInfoPersian
        {
            get
            {
                return PersianColorName + " " + PersianColorCode ;
            }
        }

        public string FullInfo
        {
            get
            {
                return InterNationalColorName + " " + InterNationalColorCode + " " + PersianColorName ;
            }
        }

        public int CodeBase1 {
            get {
                var cb = InterNationalColorCode.Substring(0, InterNationalColorCode.IndexOf('.'));
                
                return int.Parse(cb) ;
            }
        }

        //public string CodeBase2
        //{
        //    get
        //    {
        //        var cb = InterNationalColorCode.Substring(0, InterNationalColorCode.IndexOf('.'));
        //        if (cb.Length == 2)
        //        {
        //            cb = cb.Substring(1);
        //        }                
        //        return cb;
        //    }
        //}


        public int CodeDetail1
        {
            get {
                var cd= InterNationalColorCode.Substring(InterNationalColorCode.IndexOf('.')+1);
                return int.Parse(cd);
            }
        }

       
        //public string CodeDetail2
        //{
        //    get
        //    {
        //        var cd = InterNationalColorCode.Substring(InterNationalColorCode.IndexOf('.') + 1);
        //        if (cd.Length == 2)
        //        {
        //            cd = cd.Substring(1);
        //        }
        //        return cd;
        //    }
        //}
    }
}