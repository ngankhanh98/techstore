using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using techstore.DTO;

namespace techstore.DAO
{
    public class ProductDAO
    {
        public DataTable OnLoad()
        {
            string query = "SELECT * FROM Products";
            return ProcessData.Query(query);
        }
        public int OnUpdate(Product product)
        {
            string cmd = string.Format("UPDATE `Products` SET `Price`={2},`Description`='{3}',`Available`={4} WHERE `Name`='{0}' AND `Brand`='{1}'", product.name, product.brand, product.price, product.des, product.available);
            return ProcessData.Exec(cmd);
        }
        public int OnInsert(Product product)
        {
            string cmd = string.Format("INSERT INTO `Products`(`Name`, `Brand`, `Price`, `Description`, `Available`) VALUES ('{0}','{1}',{2},'{3}',{4})",product.name, product.brand, product.price, product.des, product.available);
            return ProcessData.Exec(cmd);
        }
        public int OnDelete(Product product)
        {
            string cmd = string.Format("DELETE FROM `Products` WHERE `Name`='{0}' AND `Brand`='{1}'", product.name, product.brand);
            return ProcessData.Exec(cmd);
        }
    }
}
