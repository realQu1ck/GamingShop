using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingShop.ViewModel
{
    public class InsertViewModel
    {
        public int PlatformId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string AccountCount { get; set; }
        public string ReleaseDate { get; set; }
        public int GenderId { get; set; }
        public List<IFormFile> Img { get; set; }
    }
}
