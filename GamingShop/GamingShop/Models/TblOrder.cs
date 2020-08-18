using GamingShop.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamingShop.Models
{
    public class TblOrder
    {
        public int? Id { get; set; }
        public string ClientId { get; set; }
        [ForeignKey("ClientId")]
        public string SellerUserId { get; set; }
        [ForeignKey("SellerUserId")]
        public ApplicationUser SellerUserApplicationUser { get; set; }
        public int AllId { get; set; }
        [ForeignKey("AllId")]
        public TblAll TblAll { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public TblProduct TblProduct { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
        public string Price { get; set; }
    }
}
