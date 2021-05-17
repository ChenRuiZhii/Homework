using System;
using System.Data.Entity;
using System.Linq;
using T6;
using MySql.Data.EntityFramework;


namespace T8
{[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class OrderModel : DbContext
    {
      
        public OrderModel()
            : base("OrderModel")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderModel>());
        }

        public DbSet<Order> orders { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Commodity> commodities { get; set; }

       // public DbSet<OrderService> orderServices { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}