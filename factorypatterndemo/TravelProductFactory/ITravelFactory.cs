using System;
using factorypatterndemo.TravelProduct;
namespace factorypatterndemo.TravelProductFactory
{
    public interface ITravelFactory
    {
        IDomesticTravel createDomesticTravel();
        IOutboundTravel createOutboundTravel();
        ICruiseTravel createCruiseTravel();
    }
}
