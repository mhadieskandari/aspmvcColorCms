using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.Areas.Admin.Models
{
    public class PaintingWay
    {
        public byte Id { set; get; }

        public string Name { set; get; }

        public string Description { set; get; }

        public string Content { set; get; }

        public virtual IEnumerable<Mixer> Mixers { set; get; }

    }
}