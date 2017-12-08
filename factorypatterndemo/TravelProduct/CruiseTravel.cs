using System;
namespace factorypatterndemo.TravelProduct
{
    /// <summary>
    /// 邮轮游
    /// </summary>
    public class CruiseTravel:ITravelProduct
    {
        public string GetLineList() => "您获取到邮轮游的线路列表啦！";
    }
}
