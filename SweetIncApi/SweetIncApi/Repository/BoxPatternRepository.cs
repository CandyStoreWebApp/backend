using AutoMapper;
using EntityFrameworkPaginateCore;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.BoxPattern;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class BoxPatternRepository : BaseRepository<BoxPattern>, IBoxPatternRepository
    {
        public BoxPatternRepository(CandyStoreContext context) : base(context)
        {

        }
        public new Page<BoxPattern> GetAll()
        {
            var list = _context.Set<BoxPattern>()
                .Include(x => x.Boxes)
                .AsNoTracking();
            var sortedList = list
                .Paginate(1, list.Count());
            return sortedList;
        }

        private readonly int _SortName = 1;
        private readonly int _SortPrice = 2;
        private readonly int _SortLowerAge = 3;
        private readonly int _SortUpperAge = 4;
        public Page<BoxPattern> GetAll(BoxPatternPagingVM queries)
        {
            #region filters
            var filters = new Filters<BoxPattern>();
            filters.Add(!string.IsNullOrEmpty(queries.Name), 
                x => x.Name.Contains(queries.Name));
            filters.Add(queries.PriceMin >= 0,
                x => x.Price >= queries.PriceMin);
            filters.Add(queries.PriceMax > 0,
                x => x.Price <= queries.PriceMax);
            filters.Add(queries.Status != null,
                x => x.Status == queries.Status);
            #endregion

            #region sorts
            var sorts = new Sorts<BoxPattern>();
            sorts.Add(queries.SortField == _SortName,
                x => x.Name, queries.IsDescending);
            sorts.Add(queries.SortField == _SortPrice,
                x => x.Price, queries.IsDescending);
            sorts.Add(queries.SortField == _SortLowerAge,
                x => x.LowerAge, queries.IsDescending);
            sorts.Add(queries.SortField == _SortUpperAge,
                x => x.UpperAge, queries.IsDescending);
            #endregion

            var list = _context.Set<BoxPattern>()
                .Include(x => x.Boxes)
                .AsNoTracking();
            var sortedList = list
                .Paginate(queries.PageNumber, queries.PageSize, sorts, filters);
            return sortedList;
        }
                
        public new BoxPattern GetByPrimaryKey(int id)
        {
            var boxPattern = _context.Set<BoxPattern>()
                .Include(x => x.Boxes)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return boxPattern;
        }

        public new BoxPattern Update(BoxPattern entity)
        {
            var boxPattern = _context.Set<BoxPattern>()
                .Update(entity).Entity;
            _context.SaveChanges();
            if (boxPattern == null) return null;

            var returnBoxPattern = GetByPrimaryKey(boxPattern.Id);
            return returnBoxPattern;
        }

        public new BoxPattern Add(BoxPattern entity)
        {
            var boxPattern = _context.Set<BoxPattern>()
                .Add(entity).Entity;
            _context.SaveChanges();
            if (boxPattern == null) return null;

            _context.Entry(boxPattern)
                .Collection(x => x.Boxes)
                .Load();
            return boxPattern;
        }


    }
}
