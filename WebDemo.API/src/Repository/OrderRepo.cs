using Microsoft.EntityFrameworkCore;
using WebDemo.API.src.Database;
using WebDemo.Business.src.Shared;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.API.src.Repository
{
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        private readonly DbSet<OrderDetail> _orderDetails;
        private readonly DbSet<Product> _products;
        private readonly DbSet<Order> _orders;

        public OrderRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
            _orderDetails = _databaseContext.OrderDetails;
            _products = _databaseContext.Products;
            _orders = _databaseContext.Orders;
        }

        public override async Task<Order> CreateOneASync(Order createObject)
        {
            using (var transaction = await _databaseContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var order = new Order { UserId = createObject.UserId, Id = Guid.NewGuid() };
                    Console.WriteLine(order.UserId);
                    foreach (var detail in createObject.OrderDetails)
                    {
                        var foundProduct = await _products.FindAsync(detail.ProductId);
                        if (foundProduct is null)
                        {
                            throw CustomException.NotFound($"ProductId {detail.ProductId} is not found");
                        }
                        else if (detail.Quantity > foundProduct.Inventory)
                        {
                            throw CustomException.BadRequest("Do not have enough quantity");
                        }
                        else
                        {
                            detail.OrderId = order.Id;
                            Console.WriteLine(order.Id);
                            await _orderDetails.AddAsync(detail);
                        }
                    }
                    // return await base.CreateOneASync(order);
                    await _orders.AddAsync(order);
                    await _databaseContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return order;
                }
                catch (CustomException)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}