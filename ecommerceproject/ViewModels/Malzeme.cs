﻿using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace ecommerceproject.Models
{
    public class MalzemeCreateModel
    {

        public int Id { get; set; }

        [StringLength(512, MinimumLength = 3)]
        [Required]
        [Display(Name = "Kitap Adı")]
        public string Title { get; set; } // nvarchar(512), not nullable

        public string Description { get; set; }

        public Decimal Price { get; set; }

        public int StockCount { get; set; }


        public int CategoryId { get; set; }
        //[ForeignKey("CategoryId")]

        public IFormFile Image { get; set; }

        public MalzemeCreateModel()
        {

            //  double result = 4.0 / 2.0; //2.0000000000000000000000001 1.9999999999999999999999998
        }

    }
}
