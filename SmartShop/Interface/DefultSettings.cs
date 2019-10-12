using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Interface
{
   public class DefultSettings
    {
        public static int GetNewId(DataTable dataTable)
        {
            DataTable table = dataTable;
            if (table.Rows.Count == 0) return 1;
            int max = Convert.ToInt32(table.Rows[0]["serial"]);
            for (int i = 1; i < table.Rows.Count; i++)
            {
                if (Convert.ToInt32(table.Rows[i]["serial"]) > max)
                    max = Convert.ToInt32(table.Rows[i]["serial"]);
            }
            return max + 1;
        }
    }
}
