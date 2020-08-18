using GamingShop.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamingShop.Models
{
    public class TblWishList
    {
        public int Id { get; set; }
        public bool ispaied { get; set; }
        public DateTime creationDate { get; set; }
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public ApplicationUser Customer { get; set; }
        public ICollection<TblWishList> TblWishLists { get; set; }
    }
}
