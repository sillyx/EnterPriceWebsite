using System;
using System.Collections.Generic;
using System.Linq;
using model = sniper.service.Models;

namespace sniper.service
{
    public class AboutUsService
    {
        public model.AboutUs Get()
        {
            var sql = "select * from [AboutUs]";
            var us = new model.AboutUs();
            using (var sReader = SqlDBHelper.ExecuteReader(sql))
            {
                while (sReader.Read())
                {
                    us.Id = sReader["Id"].ToString();
                    us.Cont = sReader["Cont"].ToString();
                }
            }
            return us;
        }
    }
}
