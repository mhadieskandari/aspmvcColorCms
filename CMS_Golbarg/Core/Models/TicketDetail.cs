using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Golbarg.Core.Models
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