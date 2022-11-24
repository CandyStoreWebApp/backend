using EntityFrameworkPaginateCore;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Brand;
using SweetIncApi.Models.DTO.Category;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CandyStoreContext context) : base(context)
        {
        }

        private readonly int _SortName = 1;
        private readonly int _SortOriginId = 1;
        public new Page<Category> GetAll(CategoryPagingVM queries)
        {
            #region filters
            var filters = new Filters<Category>();
            filters.Add(!string.IsNullOrEmpty(queries.Name), x => x.Name.Contains(queries.Name));
            #endregion

            #region sorts
            var sorts = new Sorts<Category>();
            sorts.Add(queries.SortField == _SortName,
                x => x.Name, queries.IsDescending);
            #endregion

            var list = _context.Set<Category>()
                .Include(x => x.Products)
                .AsNoTracking();
            var sortedList = list
                .Paginate(queries.PageNumber, queries.PageSize, sorts, filters);
            return sortedList;
        }

        public new Page<Category> GetAll()
        {
            var list = _context.Set<Category>()
                .Include(x => x.Products)
                .AsNoTracking();
            var sortedList = list
                .Paginate(1, list.Count());
            return sortedList;
        }

        public new Category GetByPrimaryKey(int id)
        {
            var catagory = _context.Categories
                .Include(x => x.Products)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return catagory;
        }

        public new Category Update(Category entity)
        {
            var catagory = _context.Set<Category>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var returnCategory = GetByPrimaryKey(catagory.Id);
            return returnCategory;
        }

        public new Category Add(Category entity)
        {
            var catagory = _context.Set<Category>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(catagory)
                .Collection(x => x.Products)
                .Load();
            return catagory;
        }
    }
}
