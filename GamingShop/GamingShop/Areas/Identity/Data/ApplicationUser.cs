using GamingShop.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingShop.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public byte[] ProfileImg { get; set; }
        public ICollection<TblProduct> TblProducts { get; set; }
        public ICollection<TblFactor> TblFactors { get; set; }
        public ICollection<TblOrder> TblOrders { get; set; }
        public ICollection<TblTicket> TblTickets { get; set; }
        public ICollection<TblPurchaseCart> TblPurchaseCarts { get; set; }
        public ICollection<TblWishList> TblWishList { get; set; }
    }
}
