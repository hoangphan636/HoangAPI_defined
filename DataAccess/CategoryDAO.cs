using BusinessObject;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static List<Category> GetCategory()
        {
            var list = new List<Category>();
            try
            {
                using (var context = new FUFlowerSystemDbContext())
                {
                    list = context.Category.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
    }
}
