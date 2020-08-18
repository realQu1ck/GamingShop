using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamingShop.Models
{
    public class TblWishListItem
    {
        public int Id { get; set; }
        public int count { get; set; }

        public int WishCartId { get; set; }
        [ForeignKey("WishCartId")]
        public TblWishList TblWishList { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public TblProduct TblProduct { get; set; }
    }
}
