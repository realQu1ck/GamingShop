using GamingShop.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamingShop.Models
{
    public class TblFactor
    {
        public int? Id { get; set; }
        public int? AllId { get; set; }
        [ForeignKey("AllId")]
        public TblAll TblAll { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public TblProduct TblProduct { get; set; }
        public int PlatformId { get; set; }
        [ForeignKey("PlatformId")]
        public TblPlatform TblPlatform { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public TblCategory TblCategory { get; set; }
        public string SellerUserId { get; set; }
        [ForeignKey("SellerUserId")]
        public string BuyUserId { get; set; }
        [ForeignKey("BuyUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public string Price { get; set; }
        public string DateTime { get; set; }
    }
}
