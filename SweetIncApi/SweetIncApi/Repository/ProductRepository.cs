using EntityFrameworkPaginateCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Product;
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

        private readonly int _SortId = 1;
        private readonly int _SortName = 2;
        private readonly int _SortBrand = 3;
        private readonly int _SortCategory = 4;
        public new Page<Product> GetAll(ProductPagingVM queries)
        {
            #region filters
            var filters = new Filters<Product>();
            filters.Add(!string.IsNullOrEmpty(queries.Name), x => x.Name.Contains(queries.Name));
            filters.Add(queries.QuantityMin >= 0, 
                x => x.Quantity >= queries.QuantityMin);
            filters.Add(queries.QuantityMax > 0, 
                x => x.Quantity <= queries.QuantityMax);
            filters.Add(queries.PriceMin >= 0, 
                x => x.Price >= queries.PriceMin);
            filters.Add(queries.PriceMax > 0, 
                x => x.Price <= queries.PriceMax);
            filters.Add(queries.Status != null, 
                x => x.Status == queries.Status);
            filters.Add(queries.CategoryId > 0, 
                x => x.CategoryId == queries.CategoryId);
            filters.Add(queries.BrandId > 0, 
                x => x.BrandId == queries.BrandId);
            #endregion

            #region sorts
            var sorts = new Sorts<Product>();            
            sorts.Add(queries.SortField == _SortId, 
                x => x.Id, queries.IsDescending);
            sorts.Add(queries.SortField == _SortName, 
                x => x.Name, queries.IsDescending);
            sorts.Add(queries.SortField == _SortBrand,
                x => x.BrandId, queries.IsDescending);
            sorts.Add(queries.SortField == _SortCategory,
                x => x.CategoryId, queries.IsDescending);
            #endregion

            var list = _context.Products
                .Include(x => x.BoxProducts)
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .AsNoTracking();
            var sortedList = list
                .Paginate(queries.PageNumber, queries.PageSize, sorts, filters);
            return sortedList;
        }

        public new Page<Product> GetAll()
        {
            var list = _context.Products
                .Include(x => x.BoxProducts)
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .AsNoTracking();
            var sortedList = list
                .Paginate(1, list.Count());
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
