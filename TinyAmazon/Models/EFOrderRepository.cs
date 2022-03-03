using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyAmazon.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        public BookstoreContext context;
        public EFOrderRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Order> Orders => context.Orders
            .Include(x => x.Lines)
            .ThenInclude(x => x.Book);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(x => x.Book));
            if (order.DonationID == 0)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}
