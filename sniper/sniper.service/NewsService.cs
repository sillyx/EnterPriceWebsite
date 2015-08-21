using System;
using System.Collections.Generic;
using System.Linq;
using sniper.service.Models;

namespace sniper.service
{
    public class NewsService
    {
        public List<News> GetList(int page, int size, out int total)
        {
            var sql = "select * from News order by CreateTime DESC";
            List<News> list = new List<News>();
            using (var sReader = SqlDBHelper.ExecuteReader(sql))
            {
                while (sReader.Read())
                {
                    var news = new News
                    {
                        Id = sReader["Id"].ToString(),
                        Title = sReader["Title"].ToString(),
                        Cont = sReader["Cont"].ToString(),
                        CreateTime = Convert.ToDateTime(sReader["CreateTime"])
                    };
                    list.Add(news);
                }
            }
            total = list.Count;
            return list.Skip(size * (page - 1)).Take(size).ToList();
        }

        public News Details(string newsId)
        {
            var sql = "select * from News where Id='" + newsId + "'";
            var news = new News();
            using (var sReader = SqlDBHelper.ExecuteReader(sql))
            {
                while (sReader.Read())
                {
                    news.Id = sReader["Id"].ToString();
                    news.Title = sReader["Title"].ToString();
                    news.Cont = sReader["Cont"].ToString();
                    news.CreateTime = Convert.ToDateTime(sReader["CreateTime"]);
                }
            }
            return news;
        }
    }
}
