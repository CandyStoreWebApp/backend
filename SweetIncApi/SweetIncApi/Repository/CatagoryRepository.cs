using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
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

        public new List<Category> GetAll()
        {
            return _context.Set<Category>()
                .Include(x => x.Products)
                .AsNoTracking()
                .ToList();

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
