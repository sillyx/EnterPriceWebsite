using System.Collections.Generic;
using System.Linq;
using model = sniper.service.Models;

namespace sniper.service
{
    public class CategoryService
    {
        public List<model.Category> Get()
        {
            var sql = "select * from [Category]";
            var list = new List<model.Category>();
            using (var sReader = SqlDBHelper.ExecuteReader(sql))
            {
                while (sReader.Read())
                {
                    var category = new model.Category();
                    category.Id = sReader["Id"].ToString();
                    category.Name = sReader["Name"].ToString();
                    list.Add(category);
                }
            }
            return list;
        }
    }
}
