using EntityFrameworkPaginateCore;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Origin;
using SweetIncApi.Models.DTO.Product;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class OriginRepository : BaseRepository<Origin>, IOriginRepository
    {
        public OriginRepository(CandyStoreContext context) : base(context)
        {
        }

        private readonly int _SortName = 1;
        public new Page<Origin> GetAll(OriginPagingVM queries)
        {
            #region filters
            var filters = new Filters<Origin>();
            filters.Add(!string.IsNullOrEmpty(queries.Name), x => x.Name.Contains(queries.Name));
            #endregion

            #region sorts
            var sorts = new Sorts<Origin>();
            sorts.Add(queries.SortField == _SortName,
                x => x.Name, queries.IsDescending);
            #endregion

            var list = _context.Set<Origin>()
                .Include(x => x.Brands)
                .AsNoTracking();
            var sortedList = list
                .Paginate(queries.PageNumber, queries.PageSize, sorts, filters);
            return sortedList;
        }

        public new Page<Origin> GetAll()
        {
            var list = _context.Set<Origin>()
                .Include(x => x.Brands)
                .AsNoTracking();
            var sortedList = list
                .Paginate(1, list.Count());
            return sortedList;
        }

        public new Origin GetByPrimaryKey(int id)
        {
            var origin = _context.Origins
                .Include(x => x.Brands)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return origin;
        }

        public new Origin Update(Origin entity)
        {
            var origin = _context.Set<Origin>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var updateOrigin = GetByPrimaryKey(origin.Id);
            return origin;
        }

        public new Origin Add(Origin entity)
        {
            var origin = _context.Set<Origin>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(origin)
                .Collection(x => x.Brands)
                .Load();
            return origin;
        }
    }
}
