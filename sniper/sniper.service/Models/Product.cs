using System;

namespace sniper.service.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string ImgSrc { get; set; }
        public DateTime CreateTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}