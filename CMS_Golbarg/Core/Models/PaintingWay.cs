using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Golbarg.Core.Models
{
    public class PaintingWay
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Display(Name = "نام روش")]
        public string Name { set; get; }

        [Display(Name = "توضیحات")]
        public string Description { set; get; }

        [Display(Name = "دستور رنگ گذاری")]
        public string Content { set; get; }

        public virtual IEnumerable<Mixer> Mixers { set; get; }

    }
}