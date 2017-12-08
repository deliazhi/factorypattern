using System;
namespace factorypatterndemo.TravelProduct
{
    /// <summary>
    /// 出境游
    /// </summary>
    public class OutboundTravel:ITravelProduct
    {
        public string GetLineList() => "您获取到出境游的线路列表啦！";
    }
}
