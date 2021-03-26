using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T5
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            OrderDetails recreationalMachines = new OrderDetails("游戏机", 1000.00);
            OrderDetails handle = new OrderDetails("游戏手柄", 100.00);
            OrderDetails kfc = new OrderDetails("KFC全家桶", 200.00);
            OrderDetails computer = new OrderDetails("电脑", 500.00);
            OrderDetails tea = new OrderDetails("茶叶", 50.00);
            recreationalMachines.number = 1;
            handle.number = 2;
            kfc.number = 5;
            computer.number = 6;
            tea.number = 10;
            Order orderA = new Order("1", "A", "三月一日",  "珞珈山路");
            orderA.orderDetails.Add(kfc);
            orderA.orderDetails.Add(tea);
            orderA.AddToSum();
            Order orderB = new Order("4", "B", "三月四日",  "珞珈山庄");
            orderB.orderDetails.Add(kfc);
            orderB.orderDetails.Add(computer);
            orderB.AddToSum();
            Order orderC = new Order("3", "C", "三月六日",  "洪波门");
            orderC.orderDetails.Add(computer);
            orderC.AddToSum();
            Order orderD = new Order("2", "D", "四月一日",  "枫园一路");
            orderD.orderDetails.Add(recreationalMachines);
            orderD.orderDetails.Add(handle);
            orderD.AddToSum();

            orderService.orders.Add(orderA);
            orderService.orders.Add(orderB);
            orderService.orders.Add(orderC);
            orderService.orders.Add(orderD);

            while (true)
            {
                Console.WriteLine("请选择服务：1、增  2、删  3、改  4、查");
                string str = Console.ReadLine();
                switch (str)
                {
                    case "1":orderService.AddOrder();break;
                    case "2":orderService.DeleteOrder();break;
                    case "3":orderService.ModifyOrder();break;
                    case "4":orderService.SearchOrder();break;

                }
            }


        }
    }

    class Customer
    {
        public string customername { get; set; }
        public override string ToString()
        {
            return "用户名为：" + customername;
        }
    }

    class Order//订单ID，客户，下单时间，总金额，配送地址
    {
        public override string ToString()
        {
            return "订单号：" + id + "下单时间：" + oderTime + "总价格" + sumPrice + customer.ToString() + "地址："+ address;
        }
        public Customer customer=new Customer();
        public int id { get; set; }
        public string oderTime { get; set; }
        public double sumPrice { get; set; }
        public string address { get; set; }

        public List<OrderDetails> orderDetails = new List<OrderDetails>();

        public void AddToSum()
        {
            sumPrice = 0;
            foreach (OrderDetails i in orderDetails)
            { sumPrice += i.commodity.comPrice * i.number; }
        }
        public Order() { }
        public Order(string id, string customer, string orderTime, string address)
        {
            this.id = int.Parse(id);
            this.customer.customername = customer;
            this.oderTime = orderTime;

            this.address = address;
        }
        public bool Equals(Order a)
        {
            if (this.id == a.id )
                return true;
            else return false;
        }
    }

    class Commodity
    {
        public override string ToString()
        {
            return "商品名：" + comName + "价格:" + comPrice;
        }
        public string comName { get; set; }
        public double comPrice { get; set; }
        public Commodity(string name,double price)
        {
            comName = name;
            comPrice = price;
        }
    }
    class OrderDetails//商品，单价，数量
    {
        public override string ToString()
        {
            return commodity.ToString() + "数量：" + number;
        }
        public Commodity commodity;
        public int number { get; set; }
        public OrderDetails(string com,double price)
        {
            commodity = new Commodity(com, price);
        }
        public OrderDetails(string com, double price, int num)
        {
            commodity = new Commodity(com, price);
            this.number = num;
        }
        public bool Equals(OrderDetails a)
        {
            if (this.commodity == a.commodity) return true;
            else return false;
        }
    }

    class OrderService
    {
        public List<Order> orders = new List<Order>();
        //增删改查
        public void AddOrder()
        {
            string str, id, cus, oderTime, price, add,comName;
            double pri;
            int num;
            Console.WriteLine("开始增添新的订单！请依次输入：订单ID，客户，下单时间，配送地址");
            id = Console.ReadLine();
            cus = Console.ReadLine();
            oderTime = Console.ReadLine();
            add = Console.ReadLine();
            Order newOrder = new Order(id,cus,oderTime,add);//尚未add
            foreach (Order i in orders)
            {
                if (newOrder.Equals(i))
                {
                    Console.WriteLine("重复添加！");
                    return;
                }
            }
            bool isOver=false;
            while(!isOver)
            {
                Console.WriteLine("正在增添订单明细！请输入货物名称，单价，数量");
                comName = Console.ReadLine();
                str = Console.ReadLine();
                pri = double.Parse(str);
                str = Console.ReadLine();
                num = int.Parse(str);
                OrderDetails newDetails = new OrderDetails(comName, pri, num);
                bool isAdd = false;
                foreach (OrderDetails i in newOrder.orderDetails)
                {
                    if (newDetails.Equals(i))
                    {
                        Console.WriteLine("重复添加！该数据不会被添加！");
                        isAdd = true;
                        break;
                    }

                }
                if (isAdd == false)
                    newOrder.orderDetails.Add(newDetails);
                Console.WriteLine("添加完成？（输入1以继续添加，任意键以完成添加！）");
                if(Console.ReadLine()=="1")
                    {
                }
                else
                    isOver = true;
                newOrder.AddToSum();

            }
            orders.Add(newOrder);
            SortOrders();
        }

        public void DeleteOrder()
        {
            Console.WriteLine("请输入想要删除的订单号：");
            string str;
            str = Console.ReadLine();
            foreach (Order i in orders)
            {
                if (int.Parse(str)==i.id)
                {
                    Console.WriteLine("已删除！");
                    orders.Remove(i);
                    return;
                }
            }
            Console.WriteLine("未找到相应订单！");

        }

        public void ModifyOrder()
        {
            string str;
            bool isfind=false;
            Console.WriteLine("请输入想要修改的订单号：");
            str = Console.ReadLine();
            Order modifyOrder=new Order();
            foreach (Order i in orders)
            {
                if (int.Parse(str)==i.id)
                {
                    modifyOrder = i;
                    isfind = true;
                    break;
                }

            }
            if (!isfind) return;
            Console.WriteLine("请输入想要修改的项目（1：客户  2：下单时间  3、配送地址  按任意键返回）：");

            switch (str)
            {
                case "1":
                    Console.WriteLine("输入客户名：");
                    str = Console.ReadLine();
                    modifyOrder.customer.customername = str;
                    break;
                case "2":
                    Console.WriteLine("输入下单时间：");
                    str = Console.ReadLine();
                    modifyOrder.oderTime = str;
                    break;
                case "3":
                    Console.WriteLine("输入配送地址：");
                    str = Console.ReadLine();
                    modifyOrder.address = str;
                    break;
                default: break;
            }
        }
        public void SortOrders()
        {
            orders.Sort((p1, p2) => (p1.id - p2.id));
        }
        public void SearchOrder()
        {
            Console.WriteLine("您想要输出所有订单还是查询某一订单？（输入1以查询所有(按总金额排序返回)  按任意键进行精准查询）");
            string str;
            str = Console.ReadLine();
            if (str == "1")
            {
                var all = from o in orders
                          orderby o.sumPrice
                          select o;
                foreach(Order i in all)
                {
                    Console.WriteLine(i.ToString());
                }
            }
            else
            {
                Console.WriteLine("输入订单号：");
                str = Console.ReadLine();
                foreach(Order i in orders)
                {
                    if(i.id==int.Parse(str))
                    {
                        Console.WriteLine(i.ToString());
                        return;
                    }
                }
                Console.WriteLine("订单号未查询到！");
            }
        }
    }


}
