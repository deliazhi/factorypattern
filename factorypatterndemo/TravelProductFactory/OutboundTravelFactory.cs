using System;
using factorypatterndemo.TravelProduct;
namespace factorypatterndemo.TravelProductFactory
{
    /// <summary>
    /// 生产出境游产品的工厂
    /// </summary>
    public class OutboundTravelFactory:ITravelProductFactory
    {
        public ITravelProduct getTravelProductType()
        {
            return new OutboundTravel();
        }
    }
}
