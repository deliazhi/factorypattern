using System;
namespace factorypatterndemo.TravelProduct
{
    /// <summary>
    /// 国内游
    /// </summary>
    public class DomesticTravel:ITravelProduct
    {
        public string GetLineList() => "您获取到国内游的线路列表啦！";
    }
}
