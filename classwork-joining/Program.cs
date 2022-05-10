using System;
using System.Linq;

namespace classwork_joining
{
    public class Program
    {
        static void Main()
        {
            var allSales = Sales.GetSales();
            var allItems = Items.GetItems();


            var joinItems = allSales.GroupJoin(allItems, x => x.Id,
                                                          y => y.SalesId,
                                                          (x, groupedItems) => new
                                                          {
                                                              x.Id,
                                                           x.CategoryName,
                                                           groupedItems
   
                                                          });
            foreach (var item in joinItems)
            {
                Console.WriteLine($"CategoryName: {item.CategoryName}");
                foreach (var item2 in item.groupedItems)
                {
                    Console.WriteLine($"Item Name: {item2.ItemName}, Id: {item2.SalesId}, Roll no: {item2.RollNumber}");
                }
                Console.WriteLine();
            }

            var sum = allItems.Sum(x => x.Amount);
            Console.WriteLine($"Total Amount: {sum}");
            Console.WriteLine();

            var averageNo = allItems.Average(x => x.RollNumber);
            Console.WriteLine($"Average Number: {averageNo}");

        }
    }
}
