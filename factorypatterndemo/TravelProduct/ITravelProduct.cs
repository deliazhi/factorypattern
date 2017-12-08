using System;
namespace factorypatterndemo.TravelProduct
{
    /// <summary>
    /// 旅游产品接口
    /// </summary>
    public interface ITravelProduct
    {
        /// <summary>
        /// 获取旅游产品线路列表
        /// </summary>
        /// <returns>The line list.</returns>
        string GetLineList();
    }
}
