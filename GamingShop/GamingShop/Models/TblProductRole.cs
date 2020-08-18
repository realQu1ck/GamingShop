using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamingShop.Models
{
    public class TblProductRole
    {
        public int? Id { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public TblCategory TblCategory { get; set; }

        public int? PlatformId { get; set; }
        [ForeignKey("PlatformId")]
        public TblPlatform TblPlatform { get; set; }

        public int? AllId { get; set; }
        [ForeignKey("AllId")]
        public TblAll TblAll { get; set; }

        public int? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public TblRolesName TblRolesName { get; set; }
    }
}
