using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.Areas.Client.Models
{
    public class Cart
    {

        public int Id { set; get; }

        [ForeignKey("MixerId")]
        public Mixer Mixer { set; get; }
        public int MixerId { set; get; }

        [ForeignKey("PayId")]
        public Pay Pay { set; get; }
        public int PayId { set; get; }

        public DateTime? RegisterDate { set; get; }

        public DateTime? ConfirmDate { set; get; }

        public DateTime? EndDate { set; get; }

        public DateTime? StartDay { set; get; }

       





    }
}