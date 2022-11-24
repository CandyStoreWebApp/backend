using EntityFrameworkPaginateCore;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models;
using SweetIncApi.Models.DTO.Box;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class BoxRepository : BaseRepository<Box>, IBoxRepository
    {

        public BoxRepository(CandyStoreContext context) : base(context)
        {
        }

        private readonly int _SortBoxPatternId = 1;
        public Page<Box> GetAll()
        {
            var list = _context.Set<Box>()
                .Include(x => x.BoxPattern)
                .Include(x => x.OrderDetails)
                .Include(x => x.BoxProducts).ThenInclude(x => x.Product)
                .AsNoTracking();
            var sortedList = list
                .Paginate(1, list.Count());
            return sortedList;
        }
        public Page<Box> GetAll(BoxPagingVM queries)
        {
            #region filters
            var filters = new Filters<Box>();
            filters.Add(queries.QuantityMin >= 0,
                x => x.Quantity >= queries.QuantityMin);
            filters.Add(queries.QuantityMax > 0,
                x => x.Quantity <= queries.QuantityMax);
            filters.Add(queries.Status != null,
                x => x.Status == queries.Status);
            filters.Add(queries.BoxPatternId > 0,
                x => x.BoxPatternId == queries.BoxPatternId);
            #endregion

            #region sorts
            var sorts = new Sorts<Box>();
            sorts.Add(queries.SortField == _SortBoxPatternId,
                x => x.BoxPatternId, queries.IsDescending);
            #endregion

            var list = _context.Set<Box>()
                .Include(x => x.BoxPattern)
                .Include(x => x.OrderDetails)
                .Include(x => x.BoxProducts).ThenInclude(x => x.Product)
                .AsNoTracking();
            var sortedList = list
                .Paginate(queries.PageNumber, queries.PageSize, sorts, filters);
            return sortedList;
        }
       
        public new Box GetByPrimaryKey(int id)
        {
            var box = _context.Set<Box>()
                .Include(x => x.BoxPattern)
                .Include(x => x.OrderDetails)
                .Include(x => x.BoxProducts)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Brand)
                .ThenInclude(x => x.Origin)

                .Include(x => x.BoxPattern)
                .Include(x => x.OrderDetails)
                .Include(x => x.BoxProducts)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Category)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return box;

        }

        public new Box Update(Box entity)
        {
            var box = _context.Set<Box>()
                .Update(entity).Entity;
            _context.SaveChanges();
            if (box == null) return null;

            var newBox = GetByPrimaryKey(box.Id);
            return newBox;
        }

        public new Box Add(Box entity)
        {
            var box = _context.Set<Box>()
                .Add(entity).Entity;
            _context.SaveChanges();
            if (box == null) return null;

            _context.Entry(box)
                .Reference(x => x.BoxPattern)
                .Load();
            return box;
        }
    }
}
