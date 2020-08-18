using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingShop.Models
{
    public class TblGender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TblAll> TblAlls { get; set; }
    }
}
