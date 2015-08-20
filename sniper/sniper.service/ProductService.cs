using System;
using System.Collections.Generic;
using System.Linq;
using model = sniper.service.Models;


namespace sniper.service
{
    public class ProductService
    {
        public List<model.Product> GetList(int page, int size, out int total)
        {
            var sql = "select * from Product order by CreateTime DESC";
            List<model.Product> list = new List<model.Product>();
            using (var sReader = SqlDBHelper.ExecuteReader(sql))
            {
                while (sReader.Read())
                {
                    var product = new model.Product
                    {
                        Id = sReader["Id"].ToString(),
                        CategoryId = sReader["CategoryId"].ToString(),
                        Description = sReader["Description"].ToString(),
                        CreateTime = Convert.ToDateTime(sReader["CreateTime"]),
                        ImgSrc = sReader["ImgSrc"].ToString(),
                        Name = sReader["Name"].ToString()
                    };
                    list.Add(product);
                }
            }
            total = list.Count;
            return list.Skip(size * (page - 1)).Take(size).ToList();
        }

        public List<model.Product> GetListByCategory(string categoryId)
        {
            var sql = "select * from Product where CategoryId='" + categoryId + "' order by CreateTime DESC";
            List<model.Product> list = new List<model.Product>();
            using (var sReader = SqlDBHelper.ExecuteReader(sql))
            {
                while (sReader.Read())
                {
                    var product = new model.Product
                    {
                        Id = sReader["Id"].ToString(),
                        CategoryId = sReader["CategoryId"].ToString(),
                        Description = sReader["Description"].ToString(),
                        CreateTime = Convert.ToDateTime(sReader["CreateTime"]),
                        ImgSrc = sReader["ImgSrc"].ToString(),
                        Name = sReader["Name"].ToString()
                    };
                    list.Add(product);
                }
            }
            return list;
        }


        public Tuple<model.Product, List<model.ImageList>> Details(string id)
        {
            var sqlProduct = "select * from Product where Id='" + id + "'";
            var sqlImgList = "select * from ImageList where ProductId='" + id + "'";
            var product = new model.Product();
            var imgList = new List<model.ImageList>();
            using (var sReader = SqlDBHelper.ExecuteReader(sqlProduct))
            {
                while (sReader.Read())
                {
                    product.Id = sReader["Id"].ToString();
                    product.CategoryId = sReader["CategoryId"].ToString();
                    product.Name = sReader["Name"].ToString();
                    product.Description = sReader["Description"].ToString();
                    product.ImgSrc = sReader["ImgSrc"].ToString();
                    product.CreateTime = Convert.ToDateTime(sReader["CreateTime"]);
                }
            }
            List<model.ImageList> list = new List<model.ImageList>();
            using (var sReader = SqlDBHelper.ExecuteReader(sqlImgList))
            {
                while (sReader.Read())
                {
                    var img = new model.ImageList
                    {
                        Id = sReader["Id"].ToString(),
                        ProductId = sReader["ProductId"].ToString(),
                        ImgSrc = sReader["ImgSrc"].ToString()
                    };
                    list.Add(img);
                }
            }
            return Tuple.Create<model.Product, List<model.ImageList>>(product, imgList);
        }
    }
}
