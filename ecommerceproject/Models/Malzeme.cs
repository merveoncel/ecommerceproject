using ecommerceproject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecommerceproject.Models
{
    public class Malzeme
    {
        internal int MalzemeId;

        public int Id { get; set; }

        [StringLength(512, MinimumLength = 3)]
        [Required]
        [Display(Name = "Ürün Adı")]
        public string Title { get; set; } // nvarchar(512), not nullable


        public string Description { get; set; }

        public Decimal Price { get; set; }

        public int StockCount { get; set; }


        public int CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public Malzeme()
        {
            CreatedDate = DateTime.Now;
            //  double result = 4.0 / 2.0; //2.0000000000000000000000001 1.9999999999999999999999998
        }

        internal Malzeme find(string id)
        {
            throw new NotImplementedException();
        }

        public virtual List<MalzemeImage> MalzemeImages { get; set; }

    }
}
