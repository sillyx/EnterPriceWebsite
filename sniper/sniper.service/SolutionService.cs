using System;
using System.Collections.Generic;
using System.Linq;
using model = sniper.service.Models;
namespace sniper.service
{
    public class SolutionService
    {
        public model.Solution Get()
        {
            var sql = "select * from [Solution]";
            var solution = new model.Solution();
            using (var sReader = SqlDBHelper.ExecuteReader(sql))
            {
                while (sReader.Read())
                {
                    solution.Id = sReader["Id"].ToString();
                    solution.Cont = sReader["Cont"].ToString();
                }
            }
            return solution;
        }
    }
}
