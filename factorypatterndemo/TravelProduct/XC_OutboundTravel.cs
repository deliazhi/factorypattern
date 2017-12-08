using System;
namespace factorypatterndemo.TravelProduct
{
    public class XC_OutboundTravel:IOutboundTravel
    {
        public string GetLineList() => "您获取到XC的出境游线路列表啦！";
    }
}
