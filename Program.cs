// See https://aka.ms/new-console-template for more information
using ShopEntity;
using Microsoft.EntityFrameworkCore;
using ShopEntity.Entites;
using Bogus;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

Random rnd = new Random();

int productCount = 100;
int categoryCount = 10;
int customerCount = 100;
int employeeCount = 100;
int orderCount = 100;
int productInOrder = 100;
int orderproductAmount = 50;

int maxSale = 20000;





List<Category> categories = new Faker<Category>().
RuleFor(x => x.Name, q => q.Lorem.Word()).
Generate(categoryCount);



List<Customer> customers = new Faker<Customer>().
RuleFor(x => x.Name, q => q.Lorem.Word()).
Generate(customerCount);

List<Employee> employees = new Faker<Employee>().
RuleFor(x => x.Name, q => q.Lorem.Word()).
Generate(employeeCount);


List<Order> orders = new Faker<Order>().
RuleFor(q => q.MyDate, w => w.Date.Between((DateTime.Now).AddDays(-100), DateTime.Now)).
Generate(orderCount);



using(Db db = new Db())
    {
    Shop shop = new() { Name = "shop" };

  

    shop.Categorys.AddRange(categories);
    

    List<Product> products = new Faker<Product>().
RuleFor(x => x.Name, q => q.Lorem.Word()).
RuleFor(x => x.Sale, q => q.Lorem.Random.Int(0, maxSale))
.Generate(productCount);

   products.ForEach(q => categories[rnd.Next(categories.Count() - 1)].Products.Add(q));

    db.Shops.Add(shop);

    db.SaveChanges();



    orders.ForEach(q =>
    {
        customers[rnd.Next(customers.Count() - 1)].Orders.Add(q);
        employees[rnd.Next(employees.Count() - 1)].Orders.Add(q);
    });


    db.Employees.AddRange(employees);
    db.Customers.AddRange(customers);



    List<OrderProduct> orderProducts = new Faker<OrderProduct>().
RuleFor(q => q.Amount, w => w.Lorem.Random.Int(0,orderproductAmount)).
RuleFor(q => q.Order, w => orders[rnd.Next(orders.Count() - 1)]).
RuleFor(q => q.Product, w => products[rnd.Next(products.Count() - 1)]).
Generate(productInOrder);
    orderProducts = orderProducts.DistinctBy(q => new { q.Order, q.Product }).ToList();
    db.OrderProducts.AddRange(orderProducts);
    /* db.SaveChanges();*/
    /* _________________________________________________________________________________
     Заполнил базу и установил связи внешних ключей*/
    Console.WriteLine("Заполнил базу и установил связи внешних ключей");
    Console.WriteLine("добавим категории с одинаковым именем,для послед удаления по условию");
    Console.WriteLine("Press any key");
    Console.ReadLine();

    db.SaveChanges();

/*--------------------------------------------------------------------------------------------------*/
   ShowDb();
Console.WriteLine("Модифицируем данные к customer.Name добавим New");
    Console.WriteLine("Press any key");
    Console.ReadLine();
    db.Customers.ForEachAsync(p => p.Name += "  New").Wait();
    db.SaveChanges();
    ShowDb();

/*-------------------------------------------------------------------------------------------------------*/
    Console.WriteLine("удалим все заказы,где менее 10 продуктов");
    Console.WriteLine("Press any key");
    Console.ReadLine();
    List<OrderProduct> orderProducts1 = db.OrderProducts.Where(q=>q.Amount>10).ToList();
    db.OrderProducts.RemoveRange(orderProducts1);
    db.SaveChanges();
    ShowDb();
    
  
    }




static void ShowDb () 
 {
    using(DbNext db1 = new DbNext())
        {
        DbSet<OrderProduct> ordpr = db1.OrderProducts;
        Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<OrderProduct, Shop> includableQueryable = ordpr.Include(q => q.Product.Category.Shop);
        Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<OrderProduct, Employee> includableQueryable1 = includableQueryable.Include(q => q.Order.Employee);
        Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<OrderProduct, Customer> includableQueryable2 = includableQueryable1.Include(q => q.Order.Customer);

        var allTable = includableQueryable2.ToList();
        /*  includableQueryable.Include(q => q.E);
          includableQueryable.Include(q => q.Order);*/

        /*    Console.WriteLine($"{Cuctomer,t}");*/
        Console.WriteLine($"{typeof(Customer).Name,Db.temp}" +
        $"{typeof(Employee).Name,Db.temp}" +
        $"{typeof(DateTime).Name,Db.temp}" +
        $"{typeof(Product).Name,Db.temp}             по цене         в количестве" +
        $"{typeof(Category).Name,Db.temp}" +
        $"{typeof(Shop).Name,Db.temp}   ");

        Console.WriteLine("");
        foreach(var item in allTable)
            {
            Console.WriteLine($"{item.Order.Customer.Name,Db.temp}" +
            $"{item.Order.Employee.Name,Db.temp}" +
            $"{item.Order.MyDate,Db.temp}" +
            $"{item.Product.Name,Db.temp}" +
            $"{item.Product.Sale,Db.temp}" +
            $"{item.Amount,Db.temp}" +
            $"{item.Product.Category.Name,Db.temp}" +
            $" {item.Product.Category.Shop.Name,Db.temp}");
            }

        }


    }






