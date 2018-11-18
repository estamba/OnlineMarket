using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMarket.Models
{
    public class EditItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public decimal price { get; set; }

        [Required]
        [AllowHtml]
        public string description { get; set; }

        [Required]
        public string  status { get; set; }
        public List<SelectListItem> StatusList { get; set; }
    }
}