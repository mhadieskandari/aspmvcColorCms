using CMS_Golbarg.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CMS_Golbarg.Core.Models;

namespace CMS_Golbarg.ViewModel
{
    public class CreateMixerViewModel
    {
        [Display(Name="رنگ موی فعلی")]
        public IEnumerable<HairColor> ActualHairColors { set; get; }
        [Display(Name = "رنگ موی درخواستی")]
        public IEnumerable<HairColor> DestinationHairColors { set; get; }

        [Display(Name = "روش های رنگ گذاری")]
        public IEnumerable<PaintingWay> PaintingWays { set; get; }


        public Mixer Mixer { set; get; }

    }
}