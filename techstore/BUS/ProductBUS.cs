using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using techstore.DAO;
using techstore.DTO;

namespace techstore.BUS
{
    public class ProductBUS
    {
        ProductDAO productDAO = new ProductDAO();

        public DataTable OnLoad()
        {
            return productDAO.OnLoad();
        }
        public int OnUpdate(Product product)
        {
            return productDAO.OnUpdate(product);
        }
        public int OnInsert(Product product)
        {
            return productDAO.OnInsert(product);
        }
        public int OnDelete(Product product)
        {
            return productDAO.OnDelete(product);
        }
    }
}
