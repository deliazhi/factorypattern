using System;
using System.Reflection;
using factorypatterndemo.TravelProduct;

namespace factorypatterndemo.TravelProductFactory
{
    /// <summary>
    /// 简单工厂模式的工厂类
    /// </summary>
    public class SimpleTravelProductFactory
    {
        public const int Domestic = 1;//国内游
        public const int Outbond = 2;//出境游
        public const int Cruise = 3;//邮轮

        public static ITravelProduct createTravelProduct(int type){
            switch(type){
                case Domestic:
                    return new DomesticTravel();
                case Outbond:
                    return new OutboundTravel();
                case Cruise:
                    return new CruiseTravel();
                default:
                    return new DomesticTravel();

            }
        }
    }

    /// <summary>
    /// 简单工厂模式工厂类的另一种写法
    /// </summary>
    public class MulWayTravelProductFactory
    {
        /// <summary>
        /// 直接指定创建的产品
        /// </summary>
        /// <returns>The domestic travel product.</returns>
        public static ITravelProduct createDomesticTravelProduct()
        {
            return new DomesticTravel();
        }

        public static ITravelProduct createOutboundTravelProduct()
        {
            return new OutboundTravel();
        }

        public static ITravelProduct createCruiseTravelProduct()
        {
            return new CruiseTravel();
        }
    }

    /// <summary>
    /// 利用反射实现的简单工厂模式
    /// </summary>
    public class ReflectTravelProductFactory
    {
        /// <summary>
        /// Creates the travel product.
        /// </summary>
        /// <returns>The travel product.</returns>
        /// <param name="fullname">类名（包括命名空间的类名）</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T createTravelProduct<T>(string fullname)
        {
            Assembly assenbly = Assembly.GetExecutingAssembly();
            return (T)assenbly.CreateInstance(fullname);
        }
    }
}
