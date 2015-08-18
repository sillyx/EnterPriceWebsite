using System;
using System.Collections.Generic;
using System.Linq;
using model=sniper.service.Models;


namespace sniper.service
{
    public class Service
    {
        public model.Service Get()
        {
            var sql = "select * from [Service]";
            var service = new model.Service();
            using (var sReader = SqlDBHelper.ExecuteReader(sql))
            {
                while (sReader.Read())
                {
                    service.Id = sReader["Id"].ToString();
                    service.Cont = sReader["Cont"].ToString();
                }
            }
            return service;
        }
    }
}
