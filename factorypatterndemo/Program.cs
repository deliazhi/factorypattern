using System;
using factorypatterndemo.TravelProduct;
using factorypatterndemo.TravelProductFactory;
namespace factorypatterndemo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("=========简单工厂模式==========");
            //string domesticLineList = SimpleTravelProductFactory.createTravelProduct(SimpleTravelProductFactory.Domestic).GetLineList();
            //Console.WriteLine(domesticLineList);

            //Console.WriteLine("=========简单工厂模式工厂类的另一种写法==========");
            //string domesticLineList = MulWayTravelProductFactory.createDomesticTravelProduct().GetLineList();
            //Console.WriteLine(domesticLineList);

            //Console.WriteLine("=========利用反射实现的简单工厂模式==========");
            //string domesticLineList = ReflectTravelProductFactory.createTravelProduct<DomesticTravel>("factorypatterndemo.TravelProduct.DomesticTravel").GetLineList();
            //Console.WriteLine(domesticLineList);

            //Console.WriteLine("=========工厂模式==========");
            //ITravelProductFactory factory = new DomesticTravelFactory();
            //ITravelProduct domesticTravel= factory.getTravelProductType();
            //string domesticLineList = domesticTravel.GetLineList();
            //Console.WriteLine(domesticLineList);

            Console.WriteLine("=========抽象工厂模式==========");
            ITravelFactory tc_factory = new TC_Factory();
            ITravelFactory xc_factory = new XC_Factory();
            IDomesticTravel tc_domesticTravel = tc_factory.createDomesticTravel();
            IDomesticTravel xc_domesticTravel = xc_factory.createDomesticTravel();
            string tc_domesticLineList = tc_domesticTravel.GetLineList();
            string xc_domesticLineList = xc_domesticTravel.GetLineList();
            Console.WriteLine(tc_domesticLineList);
            Console.WriteLine(xc_domesticLineList);
        }
    }
}
