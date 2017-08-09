using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.Areas.Admin.Models
{
    public class TicketDetail
    {
        public int Id { set; get; }


        [ForeignKey("TicketId")]
        public Ticket Ticket { set; get; }

        public int TicketId { set; get; }

        public string Content { set; get; }

        [ForeignKey("WriterId")]
        public ApplicationUser Writer { set; get; }

        public string WriterId { set; get; }





    }
}