using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerceproject.Models
{
    public class MalzemeImage
    {
        public int Id { get; set; }
        public int MalzemeId { get; set; }
        public string FileName { get; set; }
        public bool IsDefaultImage { get; set; }
        public virtual Malzeme Malzeme { get; set; }
    }
}
