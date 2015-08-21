using System;
using System.Collections.Generic;
using System.Linq;
using model = sniper.service.Models;

namespace sniper.service
{
    public class ImageListService
    {
        public List<model.ImageList> GetList(int page, int size, string productId, out int total)
        {
            var sql = "select * from ImageList where ProductId='" + productId + "'";
            List<model.ImageList> list = new List<model.ImageList>();
            using (var sReader = SqlDBHelper.ExecuteReader(sql))
            {
                while (sReader.Read())
                {
                    var product = new model.ImageList
                    {
                        Id = sReader["Id"].ToString(),
                        ImgSrc = sReader["ImgSrc"].ToSafeTrim(),
                        ProductId = sReader["ProductId"].ToSafeTrim()
                    };
                    list.Add(product);
                }
            }
            total = list.Count;
            return list.Skip(size * (page - 1)).Take(size).ToList();
        }
    }
}
