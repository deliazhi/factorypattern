using System;
using factorypatterndemo.TravelProduct;
namespace factorypatterndemo.TravelProductFactory
{
    /// <summary>
    /// 生产邮轮游产品的工厂
    /// </summary>
    public class CruiseTravelFactory:ITravelProductFactory
    {
        public ITravelProduct getTravelProductType()
        {
            return new CruiseTravel();
        }
    }
}
