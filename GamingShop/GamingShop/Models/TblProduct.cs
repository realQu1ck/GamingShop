using GamingShop.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamingShop.Models
{
    public class TblProduct
    {
        public int? Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public TblCategory TblCategory { get; set; }
        public int? PlatformId { get; set; }
        [ForeignKey("PlatformId")]
        public TblPlatform TblPlatform { get; set; }
        public int? AllId { get; set; }
        [ForeignKey("AllId")]
        public TblAll TblAll { get; set; }
        public string Level { get; set; }
        public string About { get; set; }
        public string SavedDate { get; set; }
        public int Offer { get; set; }
        public int Price { get; set; }
        public string MoneyUnit { get; set; }
        public ICollection<TblProductImg> TblProductImgs { get; set; }
        public ICollection<TblFactor> TblFactors { get; set; }
        public ICollection<TblOrder> TblOrders { get; set; }
        public ICollection<TblWishList> TblWishLists { get; set; }
        public ICollection<TblProduct> TblProducts { get; set; }
    }
}
