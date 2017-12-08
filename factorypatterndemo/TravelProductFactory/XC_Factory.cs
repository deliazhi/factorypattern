using System;
using factorypatterndemo.TravelProduct;
namespace factorypatterndemo.TravelProductFactory
{
    public class XC_Factory:ITravelFactory
    {
        public IDomesticTravel createDomesticTravel()
        {
            return new XC_DomesticTravel();
        }

        public IOutboundTravel createOutboundTravel()
        {
            return new XC_OutboundTravel();
        }

        public ICruiseTravel createCruiseTravel()
        {
            return new XC_CruiseTravel();
        }
    }
}
