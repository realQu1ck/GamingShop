using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamingShop.Models
{
    public class TblProductImg
    {
        public int Id { get; set; }
        public byte[] Img { get; set; }
        public byte[] ImgThumb { get; set; }


        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public TblProduct TblProduct { get; set; }
    }
}
