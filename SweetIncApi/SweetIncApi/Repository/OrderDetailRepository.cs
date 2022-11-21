using AutoMapper;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.BoxPattern;
using SweetIncApi.Models.DTO.Order;
using SweetIncApi.Models.DTO.OrderDetail;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly CandyStoreContext _context;

        public OrderDetailRepository(CandyStoreContext context) : base(context)
        {
            _context = context;
        }
        public List<OrderDetail> GetByOrderId(int id)
        {
            var orderedItems = _context.OrderDetails
                .Where(e => e.OrderId == id)
                .Include(e => e.Box)
                .ToList();

            return orderedItems;
        }

        public new List<OrderDetail> GetAll()
        {
            return _context.Set<OrderDetail>()
                .Include(x => x.Box)
                .Include(x => x.Order)
                .AsNoTracking()
                .ToList();
        }

        public new OrderDetail GetByPrimaryKey(int orderId, int boxId)
        {
            var orderDetail = _context.OrderDetails
                .Include(x => x.Order)
                .Include(x => x.Box)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.OrderId == orderId && x.BoxId == boxId);
            return orderDetail;

        }

        public new OrderDetail Update(OrderDetail entity)
        {
            var orderDetail = _context.Set<OrderDetail>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var returnOrderDetail = GetByPrimaryKey(orderDetail.OrderId, orderDetail.BoxId);
            return returnOrderDetail;
        }

        public new OrderDetail Add(OrderDetail entity)
        {
            var orderDetail = _context.Set<OrderDetail>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(orderDetail)
                .Reference(x => x.Box)
                .Load();
            _context.Entry(orderDetail)
                .Reference(x => x.Order)
                .Load();
            return orderDetail;
        }
    }
}
