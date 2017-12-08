using System;
namespace factorypatterndemo.TravelProduct
{
    public class TC_OutboundTravel:IOutboundTravel
    {
        public string GetLineList() => "您获取到TC的出境游线路列表啦！";
    }
}
