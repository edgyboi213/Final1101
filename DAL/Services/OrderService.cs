using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    public class OrderService
    {
        private readonly ShopContext _context = new();

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                Console.WriteLine($"{order.OrderId} {order.User} {order.DeliveryDate} {order.PickupPoint} {order.Code}");
            }
            else
            {
                Console.WriteLine("Заказ не найден!");
            }
        }

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
