using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.Areas.Admin.Models
{
    public class Ticket
    {
        public int Id { set; get; }

        public string Title { set; get; }

        public string Description { set; get; }

        public DateTime StartDate { set; get; }

        public DateTime EndDate { set; get; }

        public byte State { set; get; }

        public string UserCreatorId { set; get; }

        [ForeignKey("UserCreatorId")]
        public ApplicationUser UserCreator { set; get; }

        public string UserCloserId { set; get; }

        [ForeignKey("UserCloserId")]
        public ApplicationUser UserCloser { set; get; }



    }
}