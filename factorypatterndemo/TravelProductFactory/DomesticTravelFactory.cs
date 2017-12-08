using System;
using factorypatterndemo.TravelProduct;
namespace factorypatterndemo.TravelProductFactory
{
    /// <summary>
    /// 生产国内游产品的工厂
    /// </summary>
    public class DomesticTravelFactory:ITravelProductFactory
    {
        public ITravelProduct getTravelProductType()
        {
            return new DomesticTravel();
        }
    }
}
