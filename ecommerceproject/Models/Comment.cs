using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerceproject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }

        public int? Rating { get; set; }
        public DateTime CreatedDate { get; set; }

        public int MalzemeId { get; set; }
        public Malzeme Malzeme { get; set; }
    }
}
