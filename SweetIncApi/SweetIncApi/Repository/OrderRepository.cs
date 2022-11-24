using EntityFrameworkPaginateCore;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Brand;
using SweetIncApi.Models.DTO.Order;
using SweetIncApi.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(CandyStoreContext context) : base(context)
        {
        }

        private readonly int _SortUserId = 1;
        public new Page<Order> GetAll(OrderPagingVM queries)
        {
            #region filters
            var filters = new Filters<Order>();
            filters.Add(queries.DatetimeMin != null, 
                x => x.Datetime >= queries.DatetimeMin);
            filters.Add(queries.DatetimeMax != null,
                x => x.Datetime <= queries.DatetimeMax);
            filters.Add(queries.PaymentId != 0,
                x => x.PaymentId == queries.PaymentId);
            #endregion

            #region sorts
            var sorts = new Sorts<Order>();
            sorts.Add(queries.SortField == _SortUserId,
                x => x.UserId, queries.IsDescending);            
            #endregion

            var list = _context.Set<Order>()
                .Include(x => x.OrderDetails)
                .Include(x => x.User)
                .AsNoTracking();
            var sortedList = list
                .Paginate(queries.PageNumber, queries.PageSize, sorts, filters);
            return sortedList;
        }

        public new Page<Order> GetAll()
        {
            var list = _context.Set<Order>()
                .Include(x => x.OrderDetails)
                .Include(x => x.User)
                .AsNoTracking();
            var sortedList = list
                .Paginate(1, list.Count());
            return sortedList;
        }        

        public new Order GetByPrimaryKey(int id)
        {
            var order = _context.Orders
                .Include(x => x.OrderDetails)
                .Include(x => x.User)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return order;

        }

        public new Order Update(Order entity)
        {
            var order = _context.Set<Order>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var returnOrder = GetByPrimaryKey(order.Id);
            return order;
        }

        public new Order Add(Order entity)
        {
            var order = _context.Set<Order>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(order)
                .Collection(x => x.OrderDetails)
                .Load();
            _context.Entry(order)
                .Reference(x => x.User)
                .Load();
            return order;
        }
    }
}
