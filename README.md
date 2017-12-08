
昨天写代码的时候发现大多代码都一样，只有类型不一样，当时脑海里就冒出“工厂模式”的概念，但又说不清到底什么是工厂模式，我所遇到的情况又到底适不适合使用工厂模式，于是花时间好好把工厂模式看了一下，想通过这篇文章来输出我所看到和get到的内容。

我比较喜欢旅游，就拿旅游产品来举例子吧。

<!--more-->

## 简单工厂
首先抽象一个旅游产品接口，该接口有一个获取线路列表的行为：
```
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
```
旅游产品有很多种，比如国内游（具体的产品类）：
```
    /// <summary>
    /// 国内游
    /// </summary>
    public class DomesticTravel:ITravelProduct
    {
        public string GetLineList() => "您获取到国内游的线路列表啦！";
    }
```
再比如出境游（具体的产品类）：
```
    /// <summary>
    /// 出境游
    /// </summary>
    public class OutboundTravel:ITravelProduct
    {
        public string GetLineList() => "您获取到出境游的线路列表啦！";
    }
```
再比如邮轮游（具体的产品类）：
```
    /// <summary>
    /// 邮轮游
    /// </summary>
    public class CruiseTravel:ITravelProduct
    {
        public string GetLineList() => "您获取到邮轮游的线路列表啦！";
    }
```
然后我们来到一家OTA，看到网站上提供了如下几种旅游产品的线路列表（简单工厂类）：
```
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
```
下面就看你想选择哪种旅游产品啦，比如你想选个国内游的线路列表看看，那么，我们就让简单工厂给我们返回一下国内游的线路列表：
```
        public static void Main(string[] args)
        {
            Console.WriteLine("=========简单工厂模式==========");
            string domesticLineList = SimpleTravelProductFactory.createTravelProduct(SimpleTravelProductFactory.Domestic).GetLineList();
            Console.WriteLine(domesticLineList);
        }
```
输出结果：
```
=========简单工厂模式==========
您获取到国内游的线路列表啦！
```
如果你想获取出境游的线路列表活着邮轮游的线路列表，只需要在创建旅游产品时传入对应的产品类型即可。
显而易见，简单工厂的缺点就是，如果有很多很多种产品类型，那么你工厂类中的switch，case语句会很长，而且在做产品的扩展时，除了要增加具体的产品类外，还需要修改工厂类（往工厂类中增加case语句呀），这种情况下，你的产品和你的工厂还是有较强的耦合的，要解决这个问题，有两个方法：
一是利用反射实现简单工厂模式；二是使用工厂模式。
在这之前，我们先来看看简单工厂模式中工厂类的另一种写法：
```
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
```
此时，查看国内游线路列表的写法如下：
```
Console.WriteLine("=========简单工厂模式工厂类的另一种写法==========");
string domesticLineList = MulWayTravelProductFactory.createDomesticTravelProduct().GetLineList();
Console.WriteLine(domesticLineList);
```
输出结果：
```
=========简单工厂模式工厂类的另一种写法==========
您获取到国内游的线路列表啦！
```
这种方法虽然摆脱了switch，case语句，但依然摆脱不了具体的产品类和工厂类的耦合。所以，下面，我们就来看看利用反射实现的简单工厂模式吧！

## 利用反射实现的简单工厂模式
我们只需把工厂类生产产品的方式改成反射的方式即可。这里主要是用到了反射中，根据类名获取类实例的知识点，直接看代码吧：
```
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
```
需要注意两点：
+ 参数fullname就是类名，但是完全限定名，也就是说要包括命名空间的
+ CreateInstance创建的类实例其实是object类型的，需要强制转换一下

此时，查看国内游线路列表的写法为：
```
Console.WriteLine("=========利用反射实现的简单工厂模式==========");
string domesticLineList = ReflectTravelProductFactory.createTravelProduct<DomesticTravel>("factorypatterndemo.TravelProduct.DomesticTravel").GetLineList();
Console.WriteLine(domesticLineList);
```
输出结果：
```
=========利用反射实现的简单工厂模式==========
您获取到国内游的线路列表啦！
```
此时，具体的产品类跟工厂类已经完全解耦了。也就是说，如果需要做产品的扩展，只需要增加具体的产品类，无需修改工厂类了。
但这个方式唯一的缺点（准确点讲是问题吧）就是反射的性能有待商榷。

## 工厂模式
上面所有方式的做法就是在一个工厂里生产了所有的产品，工厂模式的做法是抽象出一个工厂接口，然后不同的产品在不同的工厂中进行生产。
（1）抽象出一个工厂接口：
```
    /// <summary>
    /// 抽象工厂接口
    /// </summary>
    public interface ITravelProductFactory
    {
        ITravelProduct getTravelProductType();//该接口有一个获取旅游产品类型的行为
    }
```
（2）不同的产品建立不同的工厂
国内游产品的工厂：
```
    /// <summary>
    /// 生产国内游产品的工厂
    /// </summary>
    public class DomesticTravelFactory:ITravelProductFactory
    {
        public ITravelProduct getTravelProductType()
        {
            return new DomesticTravel();
        }
    }
```
出境游产品的工厂：
```
    /// <summary>
    /// 生产出境游产品的工厂
    /// </summary>
    public class OutboundTravelFactory:ITravelProductFactory
    {
        public ITravelProduct getTravelProductType()
        {
            return new OutboundTravel();
        }
    }
```
邮轮游产品的工厂：
```
    /// <summary>
    /// 生产邮轮游产品的工厂
    /// </summary>
    public class CruiseTravelFactory:ITravelProductFactory
    {
        public ITravelProduct getTravelProductType()
        {
            return new CruiseTravel();
        }
    }
```
此时，查看国内游线路列表的写法如下：
```
Console.WriteLine("=========工厂模式==========");
ITravelProductFactory factory = new DomesticTravelFactory();
ITravelProduct domesticTravel= factory.getTravelProductType();
string domesticLineList = domesticTravel.GetLineList();
Console.WriteLine(domesticLineList);
```
输出结果：
```
=========工厂模式==========
您获取到国内游的线路列表啦！
```
如果要扩展产品，只需要增加对应的产品类和产品工厂即可。

大家知道，OTA不止一家，每家都有国内游、出境游、邮轮游，此时抽象工厂模式即将登场。
## 抽象工厂
（1）分别建立国内游、出境游和邮轮游的抽象接口，并继承一开始定义的ITravelProduct接口，这样就可以共用ITravelProduct接口中定义的行为了。代码如下：
```
    public interface IDomesticTravel:ITravelProduct
    {
    }
    public interface IOutboundTravel:ITravelProduct
    {
    }
    public interface ICruiseTravel:ITravelProduct
    {
    }
```
（2）定义一个OTA抽象工厂，该工厂可以生产国内游、出境游和邮轮游三种产品：
```
    public interface ITravelFactory
    {
        IDomesticTravel createDomesticTravel();
        IOutboundTravel createOutboundTravel();
        ICruiseTravel createCruiseTravel();
    }
```
（3）定义一家名叫XC的OTA工厂，该工厂继承ITravelFactory
```
    public class XC_Factory:ITravelFactory
    {
        public IDomesticTravel createDomesticTravel()
        {
            return new XC_DomesticTravel();
        }

        public IOutboundTravel createOutboundTravel()
        {
            return new XC_OutboundTravel();
        }

        public ICruiseTravel createCruiseTravel()
        {
            return new XC_CruiseTravel();
        }
    }
```
再定义一家名叫TC的OTA工厂：
```
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
```
现在，我们想要获取两家OTA的所有国内游线路列表：
```
Console.WriteLine("=========抽象工厂模式==========");
ITravelFactory tc_factory = new TC_Factory();
ITravelFactory xc_factory = new XC_Factory();
IDomesticTravel tc_domesticTravel = tc_factory.createDomesticTravel();
IDomesticTravel xc_domesticTravel = xc_factory.createDomesticTravel();
string tc_domesticLineList = tc_domesticTravel.GetLineList();
string xc_domesticLineList = xc_domesticTravel.GetLineList();
Console.WriteLine(tc_domesticLineList);
Console.WriteLine(xc_domesticLineList);
```
输出结果：
```
=========抽象工厂模式==========
您获取到TC的国内游线路列表啦！
您获取到XC的国内游线路列表啦！
```

好啦，到这里，工厂模式基本讲结束了。总结一下：
+ 工厂模式有三种：简单工厂、工厂和抽象工厂
+ 简单工厂模式中，产品类和工厂类之间存在耦合
+ 工厂模式只能解决单一商家多个产品的问题
+ 抽象工厂模式可以解决多个商家多个产品的问题

Q&A环节
Q：上面的代码中都是使用接口来表示抽象产品或者抽象工厂，可以改成用抽象类吗？
（这个问题翻译一下，其实就是抽象类和接口的区别）
A：就本实例中的接口而言，完全可以使用抽象类替换。但不是说抽象类和接口就是等价的，不然为什么会同时存在呢？存在即合理嘛，一般对象的抽象偏向使用抽象类，行为的抽象偏向使用接口。抽象类中除了有无需实现的抽象方法，也可以有具体实现的方法；而接口中只能有无实现的方法。一个类只能继承一个父类，但可以继承多个接口，所以我们在使用接口的时候有更好的扩展性，这大概就是编程原则中有一条是针对接口编程，而不是针对类编程吧。

源码地址：

差不多就这些了。

说些题外话，最近看到身边的同事小伙伴们在自己坚持不懈地努力下，慢慢成长和蜕变成更加优秀的样子，有时候我常常想，如果我一开始认识此刻的TA，大概都不敢和TA交朋友吧。没有谁天生就是优秀的，每个优秀的人背后都付出了旁人难以想象和无法看到的努力和坚持。也许我还是对自己要求太低了，由于种种原因放松了对自我成长的要求，看着自己与伙伴越来越大的差距，既羞愧又紧张，也有不少压力，也许是我还没放弃自己吧，如果要自己立刻和如此优秀的他们比，也许我连重新上路的勇气都没有，所以就和昨天的自己比吧。其实这篇文章昨天就能完成的，但我还是拖延到今天才完成，不过好在今天完成了，说明比昨天的我优秀了一点点，哈哈，只能这么安慰自己了，加油吧！
