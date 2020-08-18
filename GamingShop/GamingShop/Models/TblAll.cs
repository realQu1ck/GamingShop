using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamingShop.Models
{
    public class TblAll
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string AvailableAccountCount { get; set; }
        public string ReleaseDate { get; set; }
        public int SelledAccount { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public TblCategory TblCategory { get; set; }

        public int PlatformId { get; set; }
        [ForeignKey("PlatformId")]
        public TblPlatform TblPlatform { get; set; }
        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public TblGender TblGender { get; set; }


        public ICollection<TblProductRole> TblProductRoles { get; set; }
        public ICollection<TblProduct> TblProduct { get; set; }
        public ICollection<TblImg> TblImgs { get; set; }
        public ICollection<TblFactor> TblFactors { get; set; }
        public ICollection<TblOrder> TblOrders { get; set; }
    }
}
