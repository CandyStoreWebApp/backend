using EntityFrameworkPaginateCore;
using Microsoft.EntityFrameworkCore;
using SweetIncApi.BusinessModels;
using SweetIncApi.Models.DTO.Role;
using SweetIncApi.Models.DTO.User;
using SweetIncApi.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace SweetIncApi.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(CandyStoreContext context) : base(context)
        {
        }

        public new Page<Role> GetAll()
        {
            var list = _context.Set<Role>()
                .Include(x => x.Users)
                .AsNoTracking();
            var sortedList = list
                .Paginate(1, list.Count());
            return sortedList;
        }

        private readonly int _SortName = 1;
        public Page<Role> GetAll(RolePagingVM queries)
        {
            #region filters
            var filters = new Filters<Role>();
            filters.Add(!string.IsNullOrEmpty(queries.Name),
                x => x.Name.Contains(queries.Name));
            #endregion

            #region sorts
            var sorts = new Sorts<Role>();
            sorts.Add(queries.SortField == _SortName,
                x => x.Name, queries.IsDescending);
            #endregion

            var list = _context.Set<Role>()
                .Include(x => x.Users)
                .AsNoTracking();
            var sortedList = list
                .Paginate(queries.PageNumber, queries.PageSize, sorts, filters);
            return sortedList;
        }


        public new Role GetByPrimaryKey(int id)
        {
            var role = _context.Set<Role>()
                .Include(x => x.Users)
                .AsNoTracking()
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            return role;
        }

        public new Role Update(Role entity)
        {
            var role = _context.Set<Role>()
                .Update(entity).Entity;
            _context.SaveChanges();

            var updateRole = GetByPrimaryKey(role.Id);
            return updateRole;
        }

        public new Role Add(Role entity)
        {
            var box = _context.Set<Role>()
                .Add(entity).Entity;
            _context.SaveChanges();

            _context.Entry(box)
                .Collection(x => x.Users)
                .Load();
            return box;
        }
    }
}
