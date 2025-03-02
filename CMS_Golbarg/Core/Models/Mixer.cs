﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Golbarg.Core.Models
{
    public class Mixer
    {
        public int Id { set; get; }
        
        
        [Display(Name ="ترکیب رنگ")]
        public string Mix { set; get; }

        
        [Display(Name ="دکلره")]
        public string DeColor { set; get; }

        
        [Display(Name = "اکسیدان")]
        public string Oxidan { set; get; }

        
        [Display(Name = "رنگ موی فعلی")]
        [InverseProperty("ActualHairColor")]
        [ForeignKey("ActualHairColorID")]
        public HairColor ActualHairColor { set; get; }


        [Display(Name = "رنگ موی فعلی")]
        public int? ActualHairColorID { set; get; }

        [Display(Name = "رنگ موی درخواستی")]
        [InverseProperty("DestinationHairColor")]
        [ForeignKey("DestinationHairColorID")]
        public HairColor DestinationHairColor { set; get; }

        [Display(Name = "رنگ موی درخواستی")]
        public int? DestinationHairColorID { set; get; }

        [ForeignKey("PaintingWayId")]
        public PaintingWay PaintingWay { set; get; }

        public int PaintingWayId { set; get; }

    }
}