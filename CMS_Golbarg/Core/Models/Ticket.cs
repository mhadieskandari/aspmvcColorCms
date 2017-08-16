using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Golbarg.Core.Models
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