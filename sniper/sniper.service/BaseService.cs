﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sniper.service
{
    public class BaseService
    {
        public bool Insert<T>(T t)
        {
            var o = t.GetType();
            var sBulider = new StringBuilder("insert into ");
            sBulider.Append(o.Name);
            sBulider.Append("(");
            var properties = o.GetProperties();
            foreach (var p in properties)
            {
                sBulider.Append(p.Name);
                sBulider.Append(",");
            }
            sBulider.Length--;
            sBulider.Append(") values(");
            foreach (var p in properties)
            {
                sBulider.AppendFormat("'{0}'", p.GetValue(t, null));
                sBulider.Append(",");
            }
            sBulider.Length--;
            sBulider.Append(")");
            return SqlDBHelper.ExecuteSql(sBulider.ToString()) > 0;
        }

        public bool Delete(string tableName, string idList)
        {
            var ids = new StringBuilder();
            foreach (var id in idList.Split(','))
            {
                ids.Append("'");
                ids.Append(id);
                ids.Append("',");
            }
            ids.Length--;
            var sql = string.Format("delete from {0} where Id in ({1})", tableName, ids.ToString());
            return SqlDBHelper.ExecuteSql(sql) > 0;
        }

        public bool Update<T>(T t)
        {
            var o = t.GetType();
            var sBulider = new StringBuilder("update ");
            sBulider.Append(o.Name);
            sBulider.Append(" set ");
            var id = "";
            var properties = o.GetProperties();
            foreach (var p in properties)
            {
                var columnName = p.Name;
                var columnValue = p.GetValue(t, null);
                if (columnName == "Id")
                    id = columnValue.ToString();
                sBulider.Append(columnName);
                sBulider.AppendFormat("='{0}'", columnValue);
                sBulider.Append(",");
            }
            sBulider.Length--;
            sBulider.AppendFormat("where Id='{0}'", id);
            return SqlDBHelper.ExecuteSql(sBulider.ToString()) > 0;
        }
    }
}
