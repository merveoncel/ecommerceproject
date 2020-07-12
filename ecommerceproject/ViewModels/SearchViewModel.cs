
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecommerceproject.ViewModel
{
    public class SearchViewModel
    {
        [Display(Name = "Search Title")]
        public string SearchText { get; set; }
        [Display(Name = "Search")]
        public bool SearchInDescription { get; set; }
        [Display(Name = "Choose Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Min Price")]
        public Decimal? MinPrice { get; set; }

        [Display(Name = "Max Price")]
        public Decimal? MaxPrice { get; set; }

        public List<Models.Malzeme> Results { get; set; }
    }
}