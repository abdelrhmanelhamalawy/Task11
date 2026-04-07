using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using Task11.Data;
using Task11.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext _context = new ApplicationDbContext();


            //1-List all customers' first and last names along with their email addresses. 
            /*
            var customer = _context.Customers.Select(c=>new
            {
               c.FirstName, c.LastName, c.Email
            });
            foreach (var item in customer)
            {
                Console.WriteLine($"{item.FirstName},{item.LastName},{item.Email}");
            }
            */
            //=================================================================================//
            //2 - Retrieve all orders processed by a specific staff member(e.g., staff_id = 3). 

            /* var orders = _context.Orders.Where(o => o.StaffId == 1).Select(c => new
             {
                 c.OrderDate,
                 c.OrderStatus,
                 c.OrderId,
                 c.StaffId,
             });
             foreach (var item in orders)
             {
                 Console.WriteLine($"{item.OrderId},{item.OrderDate},{item.OrderStatus},{item.StaffId}");
             }
            */
            //=================================================================================//
            //3- Get all products that belong to a category named "Mountain Bikes".
            /*
              var products = _context.Products.Where(c => c.Category.CategoryName == "Mountain Bikes");
            foreach (var item in products)
            {
                Console.WriteLine($"{item.ProductName},{item.ModelYear},{item.Brand}");
            }
            */
            //=================================================================================//
            // 4 - Count the total number of orders per store.
            /* var orders = _context.Orders.GroupBy(o => o.StoreId).Select(o => new
            {
                o.Key,
                total = o.Count()
            });
            foreach (var item in orders )
            {
                Console.WriteLine($"{item.Key},{item.total}");
            }*/
            //=================================================================================//
            // 5- List all orders that have not been shipped yet (shipped_date is null).

            /* var orders = _context.Orders.Where(c => c.ShippedDate == null);
            foreach (var order in orders) {
                Console.WriteLine($"{order.OrderId},{order.OrderDate}");
            }
            */
            //=================================================================================//
            //6- Display each customer’s full name and the number of orders they have placed. 
            /* var customerWITHorders = _context.Customers.Include(x => x.Orders).Select(o => new
            {
                o.FirstName,
                o.LastName,
               orders =  o.Orders.Count()
            });
            foreach (var item in customerWITHorders)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName} , {item.orders}");
            }
            */
            //=================================================================================//
            // 7- List all products that have never been ordered (not found in order_items). 
            /* var products = _context.Products.Where(p => !p.OrderItems.Any()).Select(p => new {

                 p.ProductName, p.ProductId

             });
             foreach (var item in products)
             {
                 Console.WriteLine($"{item.ProductName} , {item.ProductId}");
             }
            */
            //=================================================================================//

            //8- Display products that have a quantity of less than 5 in any store stock.
            /*  var products = _context.Stocks.Include(p => p.Product).Where(s => s.Quantity < 5).Select(p => p.Product.ProductName);
              foreach (var item  in products) {

                  Console.WriteLine($"{item}");
              }
            */
            //=================================================================================//

            //9- Retrieve the first product from the products table. 
            /*
            var product =  _context.Products.FirstOrDefault();
            Console.WriteLine(product.ProductName);
            */
            //=================================================================================//

            //10- Retrieve all products from the products table with a certain model year. 
            /*var product = _context.Products.Where(p => p.ModelYear == 2018);
            foreach (var item in product)
            {

                Console.WriteLine($"{item.ProductName}");

            }*/
            //=================================================================================//
            // 11 - Display each product with the number of times it was ordered.  
            /*  var products = _context.Products.Include(o => o.OrderItems).Select(s => new
              {
                  s.ProductName,
                  ordertime = s.OrderItems.Count()
              });
              foreach (var item in products)
              {

                  Console.WriteLine($"{item.ProductName},{item.ordertime}");

              }
            */
            //=================================================================================//
            // 12 - Count the number of products in a specific category.\
            /*
            var products = _context.Products.Where(c=>c.Category.CategoryName== "Mountain Bikes").Count();
            Console.WriteLine(products);
            */
            //=================================================================================//
            //13- Calculate the average list price of products. 
            /*
            var products = _context.Products.Average(p=>p.ListPrice);
            Console.WriteLine(products);
            */
            //=================================================================================//
            //14- Retrieve a specific product from the products table by ID. 
            /* var products = _context.Products.Where(p=> p.ProductId==5);
            foreach (var item in products)
            {

                Console.WriteLine($"{item.ProductName}");

            }
            */
            //=================================================================================//
            //15- List all products that were ordered with a quantity greater than 3 in any order.
            /* var products = _context.OrderItems.Include(p=>p.Product).Where(p=> p.Quantity>3);
             foreach (var item in products)
             {

                 Console.WriteLine($"{item.Product.ProductName}");

             }
            */
            //=================================================================================//
            //16- Display each staff member’s name and how many orders they processed. 
            /* var staffs = _context.Staffs.Include(p => p.Orders).Select(p => new
             {
                 p.FirstName, p.LastName,total = p.Orders.Count()


             });
             foreach (var item in staffs)
             {

                 Console.WriteLine($"{item.FirstName}  {item.LastName},{item.total}");

             }
            */
            //=================================================================================//
            //17- List active staff members only (active = true) along with their phone numbers. 
            /* var staffs = _context.Staffs.Where(p => p.Active == 1).Select(p =>new
             {
                 p.FirstName,
                 p.Phone
             });

             foreach (var item in staffs)
             {

                 Console.WriteLine($"{item.FirstName},{item.Phone}");

             }
            */
            //=================================================================================//
            //18- List all products with their brand name and category name. 
            /*  var product = _context.Products.Select(p=>new { 

                  p.ProductId,
                  p.ProductName,
                  p.Brand.BrandName,
                  p.Category.CategoryName

              });

              */
            //=================================================================================//
            //19- Retrieve orders that are completed. 
            // var orders = _context.Orders.Where(p=>p.ShippedDate != null );
            //=================================================================================//
            //20- List each product with the total quantity sold (sum of quantity from order_items). 
            var product = _context.Products.Select(p=>
                new
                {
                    p.ProductId,
                    p.ProductName,
                    sum = p.OrderItems.Sum(q=>q.Quantity)
                }
                
                );

            //=================================================================================//
        }
    }
}
