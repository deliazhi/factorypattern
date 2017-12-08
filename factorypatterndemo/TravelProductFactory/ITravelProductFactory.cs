using System;
using factorypatterndemo.TravelProduct;
namespace factorypatterndemo.TravelProductFactory
{
    /// <summary>
    /// 抽象工厂接口
    /// </summary>
    public interface ITravelProductFactory
    {
        ITravelProduct getTravelProductType();//该接口有一个获取旅游产品类型的行为
    }
}
