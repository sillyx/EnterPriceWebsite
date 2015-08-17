using System;

namespace sniper.service.Models
{
    public class News
    {
        public string Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Title { get; set; }
        public string Cont { get; set; }
    }
}