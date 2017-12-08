using System;
using factorypatterndemo.TravelProduct;

namespace factorypatterndemo.TravelProductFactory
{
    public class TC_Factory : ITravelFactory
    {
        public ICruiseTravel createCruiseTravel()
        {
            return new TC_CruiseTravel();
        }

        public IDomesticTravel createDomesticTravel()
        {
            return new TC_DomesticTravel();
        }

        public IOutboundTravel createOutboundTravel()
        {
            return new TC_OutboundTravel();
        }
    }
}
