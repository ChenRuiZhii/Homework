using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace T6
{
    public class Program
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
            Order orderA = new Order("1", "A", "三月一日", "珞珈山路");
            orderA.orderDetails.Add(kfc);
            orderA.orderDetails.Add(tea);
            orderA.AddToSum();
            Order orderB = new Order("4", "B", "三月四日", "珞珈山庄");
            orderB.orderDetails.Add(kfc);
            orderB.orderDetails.Add(computer);
            orderB.AddToSum();
            Order orderC = new Order("3", "C", "三月六日", "洪波门");
            orderC.orderDetails.Add(computer);
            orderC.AddToSum();
            Order orderD = new Order("2", "D", "四月一日", "枫园一路");
            orderD.orderDetails.Add(recreationalMachines);
            orderD.orderDetails.Add(handle);
            orderD.AddToSum();

            orderService.orders.Add(orderA);
            orderService.orders.Add(orderB);
            orderService.orders.Add(orderC);
            orderService.orders.Add(orderD);

            while (true)
            {
                Console.WriteLine("请选择服务：1、增  2、删  3、改  4、查  5、序列化  6、反序列化");
                string str = Console.ReadLine();
                switch (str)
                {
                    case "1":

                        string str1, id1, cus1, oderTime, price, add, comName;
                        double pri;
                        int num;
                        Console.WriteLine("开始增添新的订单！请依次输入：订单ID，客户，下单时间，配送地址");
                        id1 = Console.ReadLine();
                        cus1 = Console.ReadLine();
                        oderTime = Console.ReadLine();
                        add = Console.ReadLine();
                        Order newOrder = new Order(id1, cus1, oderTime, add);//尚未add

                        bool isOver = false;
                        while (!isOver)
                        {
                            Console.WriteLine("正在增添订单明细！请输入货物名称，单价，数量");
                            comName = Console.ReadLine();
                            str1 = Console.ReadLine();
                            pri = double.Parse(str1);
                            str1 = Console.ReadLine();
                            num = int.Parse(str1);
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
                            if (Console.ReadLine() == "1")
                            {
                            }
                            else
                                isOver = true;
                            newOrder.AddToSum();

                        }
                        orderService.AddOrder(newOrder); break;

                    case "2":
                        Console.WriteLine("输入想要删除的订单号：");
                        string id =Console.ReadLine();
                        if (orderService.DeleteOrder(id)) Console.WriteLine("已删除！");
                        else Console.WriteLine("未能找到相应订单！");
                        break;
                    case "3": 
            Console.WriteLine("请输入想要修改的订单号：");
                        id = Console.ReadLine();
                        Console.WriteLine("请输入想要修改的项目（1：客户  2：下单时间  3、配送地址  按两次任意键返回）：");
                        string item = Console.ReadLine();
                        string target;
                        target = Console.ReadLine();

                      
                        orderService.ModifyOrder(id,item,target); break;

                    case "4":
                        Console.WriteLine("您想要输出所有订单还是查询某一订单？（输入1以查询所有(按总金额排序返回)  按任意键进行精准查询）");

                        string choice;
                        choice = Console.ReadLine();
                        if (choice != "1")
                            id = Console.ReadLine();
                        else id = "";
                        bool k=orderService.SearchOrder(choice,id);
                        if (k == false&&choice!="1") Console.WriteLine("未查找到该订单!");
                        break;


                    case "5":orderService.Export();break;
                    case "6":Console.WriteLine("请输入反序列化文件名：");
                        string fileName = Console.ReadLine();
                        orderService.Imort(fileName);
                        break;
                }
            }


        }
    }

    public class Customer
    {
        public Customer() { }
        public string customername { get; set; }
        public override string ToString()
        {
            return "用户名：" + customername;
        }
    }

    public class Order//订单ID，客户，下单时间，总金额，配送地址
    {
        public Order() {
            this.id = 0;
            this.customer.customername = "nil";
            this.oderTime = "nil";

            this.address = address;
        }
        public override string ToString()
        {
            return "订单号：" + id + "下单时间：" + oderTime + "总价格" + sumPrice + customer.ToString() + "地址：" + address;
        }
        public Customer customer = new Customer();
        [Key]
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
        public Order(string id, string customer, string orderTime, string address)
        {
            this.id = int.Parse(id);
            this.customer.customername = customer;
            this.oderTime = orderTime;

            this.address = address;
        }
        public bool Equals(Order a)
        {
            if (this.id == a.id)
                return true;
            else return false;
        }
    }

    public class Commodity
    {
        public override string ToString()
        {
            return "商品名：" + comName + "价格:" + comPrice;
        }
        public string comName { get; set; }
        public double comPrice { get; set; }
        public Commodity()
        {

        }
        public Commodity(string name, double price)
        {
            comName = name;
            comPrice = price;
        }
    }
     public class OrderDetails//商品，单价，数量
    {
        public override string ToString()
        {
            return commodity.ToString() + "数量：" + number;
        }
        public Commodity commodity;

        public int number { get; set; }
        [Key]
        public string comName { get; set; }
        public double comPrice { get; set; }
        public OrderDetails()
        {

        }
        public OrderDetails(string com, double price)
        {
            commodity = new Commodity(com, price);
            this.comName = com;
            this.comPrice = price;

        }
        public OrderDetails(string com, double price, int num)
        {
            commodity = new Commodity(com, price);
            this.number = num;
            this.comName = com;
            this.comPrice = price;
        }
        public bool Equals(OrderDetails a)
        {
            if (this.commodity == a.commodity) return true;
            else return false;
        }
    }

    public class OrderService
    {
        public int OrderServiceId { get; set; }
        public OrderService() { }
        public List<Order> orders = new List<Order>();
        //增删改查

      
        public void AddOrder(Order order)
        {
            try
            {
                foreach (Order i in orders)
                {
                    if (i.id==order.id)
                    {
                        throw new ApplicationException($"the order {order.id} already exists!");
                    }

                }
                
            }
            catch (ApplicationException)
            {
                return;
            }
            orders.Add(order);
            SortOrders();
        }

        public bool DeleteOrder(string id)
        {
            foreach (Order i in orders)
            {
                if (int.Parse(id) == i.id)
                {
                    orders.Remove(i);
                    return true;
                }
            }
            return false;
        }

        public bool ModifyOrder(string id,string item,string target)
        {
            bool isfind = false;
            Order modifyOrder = new Order();
            foreach (Order i in orders)
            {
                if (int.Parse(id) == i.id)
                {
                    modifyOrder = i;
                    isfind = true;
                    break;
                }

            }
            if (!isfind) return false;


            switch (item)
            {
                case "1":
                    modifyOrder.customer.customername = target;
                    break;
                case "2":
                    modifyOrder.oderTime = target;
                    break;
                case "3":
                    modifyOrder.address = target;
                    break;
                default: break;
            }
            return true;
        }
        public void SortOrders()
        {
            orders.Sort((p1, p2) => (p1.id - p2.id));
        }
        public bool SearchOrder(string choice,string id)
        {
      
            if (choice == "1")
            {
                var all = from o in orders
                          orderby o.sumPrice
                          select o;
                foreach (Order i in all)
                {
                    Console.WriteLine(i.ToString());
                }
            }
            else
            {
                foreach (Order i in orders)
                {
                    if (i.id == int.Parse(id))
                    {
                        Console.WriteLine(i.ToString());
                        return true;
                    }
                }
            }
            return false;
        }

        public void Export()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("Exported.xml", FileMode.Create))
            {
               
                xmlSerializer.Serialize(fs, orders);
                
            }
            Console.WriteLine("\n正在序列化生成XML文件！");
            Console.WriteLine(File.ReadAllText("Exported.xml"));
            
        }

        public void Imort(string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));

            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
               List<Order> ordersImport = (List<Order>)xmlSerializer.Deserialize(fs);

                Console.WriteLine("/n正在反序列化！");
            }
        }
    }


}
