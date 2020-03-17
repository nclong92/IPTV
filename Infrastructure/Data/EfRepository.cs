using Core.Interfaces;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T>, IAsyncRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(int id, bool disableTracking = true)
        {

            if (disableTracking)
            {
                return _dbContext.Set<T>().Find(id);
            }
            return _dbContext.Set<T>().Find(id);

        }
        public virtual async Task<T> GetByIdAsync(int id, bool disableTracking = true)
        {
            if (disableTracking)
            {

            }
            return await _dbContext.Set<T>().FindAsync(id);
        }

        private IQueryable<T> GetQueryBySpecification(ISpecification<T> spec, bool disableTracking = true)
        {
            var queryableResultWithIncludes = spec.Includes
           .Aggregate(_dbContext.Set<T>().AsQueryable(),
               (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression


            var query = secondaryResult
                            .Where(spec.Criteria);

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public T GetSingleBySpec(ISpecification<T> spec, bool disableTracking = true)
        {
            return GetQueryBySpecification(spec, disableTracking).FirstOrDefault();
        }
        public virtual async Task<T> GetSingleBySpecAsync(ISpecification<T> spec, bool disableTracking = true)
        {
            return await GetQueryBySpecification(spec, disableTracking)
                            .FirstOrDefaultAsync();
        }


        public List<T> ListAll(bool disableTracking = true)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            return query.ToList();
        }

        public async Task<List<T>> ListAllAsync(bool disableTracking = true)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public List<T> List(ISpecification<T> spec, bool disableTracking = true)
        {
            return GetQueryBySpecification(spec, disableTracking).ToList();
        }
        public async Task<List<T>> ListAsync(ISpecification<T> spec, bool disableTracking = true)
        {
            return await GetQueryBySpecification(spec, disableTracking).ToListAsync();
        }

        public int Count(ISpecification<T> spec, bool disableTracking = true)
        {
            return GetQueryBySpecification(spec, disableTracking).Count();
        }
        public async Task<int> CountAsync(ISpecification<T> spec, bool disableTracking = true)
        {
            return await GetQueryBySpecification(spec, disableTracking).CountAsync();
        }

        public List<T> ListPaged(ISpecification<T> spec, string sortOrder, int page = 1, int pagesize = 20, bool disableTracking = true)
        {

            var query = GetQueryBySpecification(spec, disableTracking);
            bool descending = false;

            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "Id";
            }
            else if (sortOrder.EndsWith("_desc"))
            {
                sortOrder = sortOrder.Substring(0, sortOrder.Length - 5);
                descending = true;
            }

            if (descending)
            {
                query = query.OrderByDescending(e => EF.Property<object>(e, sortOrder));
            }
            else
            {
                query = query.OrderBy(e => EF.Property<object>(e, sortOrder));
            }

            // return the result of the query using the specification's criteria expression
            return query.GetPaged(page, pagesize);
        }

        public async Task<List<T>> ListPagedAsync(ISpecification<T> spec, string sortOrder, int page = 1, int pagesize = 20, bool disableTracking = true)
        {

            var query = GetQueryBySpecification(spec, disableTracking);

            if (!string.IsNullOrEmpty(sortOrder))
            {
                bool descending = false;
                // Not set default -> DB don't include Id property
                //if (string.IsNullOrEmpty(sortOrder))
                //{
                //    sortOrder = "Id";
                //}
                //else


                if (sortOrder.EndsWith("_desc"))
                {
                    sortOrder = sortOrder.Substring(0, sortOrder.Length - 5);
                    descending = true;
                }

                if (descending)
                {
                    query = query.OrderByDescending(e => EF.Property<object>(e, sortOrder));
                }
                else
                {
                    query = query.OrderBy(e => EF.Property<object>(e, sortOrder));
                }
            }

            // return the result of the query using the specification's criteria expression
            return await query.GetPagedAsync(page, pagesize);
        }




        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
