// See https://aka.ms/new-console-template for more information
using ShopEntity;
using Microsoft.EntityFrameworkCore;
using ShopEntity.Entites;
using Bogus;


int productCount = 100;
int categoryCount = 10;
int customerCount = 1000;
int employeeCount = 1000;
int orderCount = 1000;
int productInOrder = 10;

int maxSale = 20000;





/*List<Category> categories = new Faker<Category>().
RuleFor(x => x.CategoryId, q => q.IndexFaker).
RuleFor(x => x.Name, q => q.Lorem.Word()).
RuleFor(x => x.ShopId, q => shop.ShopId).
Generate(categoryCount);

List<Product> products = new Faker<Product>().
RuleFor(x => x.ProductId, q => q.IndexFaker).
RuleFor(x => x.Name, q => q.Lorem.Word()).
RuleFor(x => x.Sale, q => q.Lorem.Random.Int(0,maxSale)).
RuleFor(x => x.CategoryId, q => categories[q.Lorem.Random.Int(0,categories.Count() - 1)].CategoryId).
Generate(productCount);

List<Customer> customers = new Faker<Customer>().
RuleFor(x => x.CustomerId, q => q.IndexFaker).
RuleFor(x => x.Name, q => q.Lorem.Word()).
Generate(customerCount);

List<Employee> employees = new Faker<Employee>().
RuleFor(x => x.EmployeeId, q => q.IndexFaker).
RuleFor(x => x.Name, q => q.Lorem.Word()).
Generate(employeeCount);


List<Order> orders = new Faker<Order>().
RuleFor(x => x.OrderId, q => q.IndexFaker).
RuleFor(x => x.CustomerId, q => customers[q.Lorem.Random.Int(0, customers.Count() - 1)].CustomerId).
RuleFor(x => x.EmployeeId, q => employees[q.Lorem.Random.Int(0, employees.Count() - 1)].EmployeeId).
Generate(orderCount);

*//*генерируем на каждый заказ productInOrder продуктов */
/*далее группируем по order-product*//*
List<OrderProduct> orderProducts = orders.SelectMany(ord => new Faker<OrderProduct>().
RuleFor(q => q.OrderId, w => ord.OrderId).
RuleFor(q => q.ProductId, q => products[q.Lorem.Random.Int(0, products.Count() - 1)].ProductId).
Generate(productInOrder)).
*//*и группируем по продуткам*//*

GroupBy(q => new { q.OrderId, q.ProductId }).
Select(q => new OrderProduct() { OrderId = q.First().OrderId, ProductId = q.First().ProductId, Amount = q.Count() }).OrderBy(q=>q.Amount).ToList();*/







using(Db db = new Db())
    {
    Shop shop = new() { ShopId = 1, Name = "shop" };
    Category cat = new Category() { CategoryId = 1, Name = "ygy", ShopId = shop.ShopId };
    db.Shops.Add(shop);
    db.Categorys.Add(cat);
/*  AddDbSet(db.Categorys, categories);*/
/*  AddDbSet(db.Products, products);
  AddDbSet(db.Employees, employees);
  AddDbSet(db.Orders, orders);*/
/*    AddDbSet(db.OrderProducts, orderProducts);*/

    db.SaveChangesAsync().Wait();
    }


static void AddDbSet<T>(DbSet<T> dbEntitys,IEnumerable<T> col) where T:class
    {
    



    dbEntitys.AddRange(col);
    
    }

   


