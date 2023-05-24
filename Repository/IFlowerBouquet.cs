using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IFlowerBouquet
    {
        List<FlowerBouquet> GetFlowerBouquet();
        void SaveFlowerBouquet(FlowerBouquet FlowerBouquet);
        FlowerBouquet FindFlowerBouquetById(int id);
        void UpdateFlowerBouquet(FlowerBouquet FlowerBouquet);

        void DeleteFlowerBouquet(FlowerBouquet FlowerBouquet);
        void UpdateFlowerBouquetStatus(int id);

    }
}
