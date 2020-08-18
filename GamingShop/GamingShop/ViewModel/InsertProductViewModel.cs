using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingShop.ViewModel
{
    public class InsertProductViewModel
    {
        public int PlatformId { get; set; }
        public int CategoryId { get; set; }
        public string About { get; set; }
        public int GameId { get; set; }
        public string Level { get; set; }
        public int Price { get; set; }
        public List<IFormFile> Img { get; set; }
    }
}
