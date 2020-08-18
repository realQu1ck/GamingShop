using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingShop.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamingShop.Models
{
    public class DBGamingShop : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<TblAll> TblAlls { get; set; }
        public DbSet<TblCategory> TblCategories { get; set; }
        public DbSet<TblPlatform> TblPlatforms { get; set; }
        public DbSet<TblImg> TblImgs { get; set; }
        public DbSet<TblProduct> TblProducts { get; set; }
        public DbSet<TblProductRole> TblProductRoles { get; set; }
        public DbSet<TblRolesName> TblRolesNames { get; set; }
        public DbSet<TblProductImg> TblProductImgs { get; set; }
        public DbSet<TblFactor> TblFactors { get; set; }
        public DbSet<TblOrder> TblOrders { get; set; }
        public DbSet<TblGender> TblGenders { get; set; }
        public DbSet<TblPurchaseCart> TblPurchaseCarts { get; set; }
        public DbSet<TblPurchaseCartItem> TblPurchaseCartItems { get; set; }
        public DbSet<TblWishList> TblWishLists { get; set; }
        public DbSet<TblWishListItem> TblWishListItems { get; set; }
        public DbSet<TblTicket> TblTickets { get; set; }
        public DBGamingShop(DbContextOptions<DBGamingShop> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
