using EntityFrameworkPaginateCore;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class ProductRepository : BaseRepository<PaymentDetail>, IProductRepository
    {
        private readonly CandyStoreContext _context;

        public ProductRepository(CandyStoreContext context) :base(context)
        {
            _context = context;
        }

        public new Page<Product> GetAll()
        {
            var filters = new Filters<Product>();
            filters.Add(true, x => x.Name.Contains("a"));

            var sorts = new Sorts<Product>();
            sorts.Add(true, x => x.Price);

            var list = _context.Products
                .AsNoTracking();
            var sortedList = list
                .Paginate(1, 5, sorts, filters);
            return sortedList;
        }

        public new Product GetByPrimaryKey(int id)
        {
            var product = _context.Set<Product>()
                .Include(x => x.Brand)
                .Include(x => x.BoxProducts)
                .Include(x => x.Category)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return product;
        }

        public new Product Update(Product entity)
        {
            var product = _context.Set<Product>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var returnProduct = GetByPrimaryKey(product.Id);
            return product;
        }

        public new Product Add(Product entity)
        {
            var product = _context.Set<Product>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(product)
                .Collection(x => x.BoxProducts)
                .Load();
            _context.Entry(product)
                .Reference(x => x.Brand)
                .Load();
            _context.Entry(product)
                .Reference(x => x.Category)
                .Load();
            return product;
        }
    }
}
