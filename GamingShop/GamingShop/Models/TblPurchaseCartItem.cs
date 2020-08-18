using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamingShop.Models
{
    public class TblPurchaseCartItem
    {
        public int Id { get; set; }
        public int count { get; set; }

        public int PurchaseCartId { get; set; }
        [ForeignKey("PurchaseCartId")]
        public TblPurchaseCart TblPurchaseCart { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public TblProduct TblProduct { get; set; }
    }
}
