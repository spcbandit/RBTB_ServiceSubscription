using Microsoft.EntityFrameworkCore;
using RBTB_ServiceSubscription.Application.Abstractions;
using RBTB_ServiceSubscription.Application.Entites;
using RBTB_ServiceSubscription.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Database.Repository
{
    public class UsersRepository : IRepository<UsersEntity>
    {
        private readonly RBTB_ServiceSubscriptionContext _context;
        private readonly DbSet<UsersEntity> _db;

        public UsersRepository(RBTB_ServiceSubscriptionContext context)
        {
            _context = context;
            _db = context.Set<UsersEntity>();
        }

        public int Create(UsersEntity entity)
        {
            _db.Add(entity);
            return _context.SaveChanges();
        }

        public UsersEntity FindById(Guid id)
        {
            return _db.Find(id);
        }

        public IEnumerable<UsersEntity> Get()
        {
            return _db.AsNoTracking()
                .ToList();
        }

        public IEnumerable<UsersEntity> Get(Func<UsersEntity, bool> predicate)
        {
            return _db.AsNoTracking()
                .Where(predicate)
                .ToList();
        }

        public IEnumerable<UsersEntity> GetWithInclude(Func<UsersEntity, bool> predicate,
            params Expression<Func<UsersEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        public IQueryable<UsersEntity> Include(params Expression<Func<UsersEntity, object>>[] includeProperties)
        {
            IQueryable<UsersEntity> query = _db.AsNoTracking();
            return includeProperties.Aggregate(query,
                (current, includeProperties) =>
                current.Include(includeProperties));
        }

        public int Remove(UsersEntity entity)
        {
            _db.Remove(entity);
            return _context.SaveChanges();
        }

        public int Update(UsersEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}
