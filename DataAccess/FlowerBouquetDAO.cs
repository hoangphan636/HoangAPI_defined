using BusinessObject;
using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FlowerBouquetDAO
    {
        public static List<FlowerBouquet> GetFlowerBouquet()
        {
            var list = new List<FlowerBouquet>();
            try
            {
                using (var context = new FUFlowerSystemDbContext())
                {
                    list = context.FlowerBouquet.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

     

        public static void SaveFlowerBouquet(FlowerBouquet FlowerBouquet)
        {

            try
            {
                using var context = new FUFlowerSystemDbContext();

                context.FlowerBouquet.Add(FlowerBouquet);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


      

        public static FlowerBouquet FindFlowerBouquetById(int id)
        {
            var list = new FlowerBouquet();
            try
            {
                using (var context = new FUFlowerSystemDbContext())
                {
                    list = context.FlowerBouquet.FirstOrDefault(x => x.FlowerBouquetID == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static void UpdateFlowerBouquet(FlowerBouquet FlowerBouquet)
        {

            try
            {
                using var context = new FUFlowerSystemDbContext();

                context.FlowerBouquet.Update(FlowerBouquet);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void DeleteFlowerBouquet(FlowerBouquet FlowerBouquet)
        {

            try
            {
                using var context = new FUFlowerSystemDbContext();

                context.FlowerBouquet.Remove(FlowerBouquet);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }












    }
}
