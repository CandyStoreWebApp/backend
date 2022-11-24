using EntityFrameworkPaginateCore;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Brand;
using SweetIncApi.Models.DTO.Origin;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(CandyStoreContext context) : base(context)
        {
        }

        private readonly int _SortName = 1;
        private readonly int _SortOriginId = 2;
        public new Page<Brand> GetAll(BrandPagingVM queries)
        {
            #region filters
            var filters = new Filters<Brand>();
            filters.Add(!string.IsNullOrEmpty(queries.Name), x => x.Name.Contains(queries.Name));
            filters.Add(queries.OriginId != 0, x => x.OriginId ==queries.OriginId);
            #endregion

            #region sorts
            var sorts = new Sorts<Brand>();
            sorts.Add(queries.SortField == _SortName,
                x => x.Name, queries.IsDescending);
            sorts.Add(queries.SortField == _SortOriginId,
                x => x.OriginId, queries.IsDescending);
            #endregion

            var list = _context.Set<Brand>()
                .Include(x => x.Products)
                .Include(x => x.Origin)
                .AsNoTracking();
            var sortedList = list
                .Paginate(queries.PageNumber, queries.PageSize, sorts, filters);
            return sortedList;
        }

        public new Page<Brand> GetAll()
        {
            var list = _context.Set<Brand>()
                .Include(x => x.Products)
                .Include(x => x.Origin)
                .AsNoTracking();
            var sortedList = list
                .Paginate(1, list.Count());
            return sortedList;
        }

        public new Brand GetByPrimaryKey(int id)
        {
            var brand = _context.Set<Brand>()
                .Include(x => x.Products)
                .Include(x => x.Origin)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return brand;

        }

        public new Brand Update(Brand entity)
        {
            var brand = _context.Set<Brand>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var returnBrand = GetByPrimaryKey(brand.Id);
            return returnBrand;
        }

        public new Brand Add(Brand entity)
        {
            var brand = _context.Set<Brand>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(brand)
                .Collection(x => x.Products)
                .Load();
            _context.Entry(brand)
                .Reference(x => x.Origin)
                .Load();
            return brand;
        }
    }
}
