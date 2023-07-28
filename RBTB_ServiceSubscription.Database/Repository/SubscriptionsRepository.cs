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
    public class SubscriptionsRepository : IRepository<SubscriptionsEntity>
    {
        private readonly RBTB_ServiceSubscriptionContext _context;
        private readonly DbSet<SubscriptionsEntity> _db;

        public SubscriptionsRepository(RBTB_ServiceSubscriptionContext context)
        {
            _context = context;
            _db = context.Set<SubscriptionsEntity>();
        }

        public int Create(SubscriptionsEntity entity)
        {
            _db.Add(entity);
            return _context.SaveChanges();
        }

        public SubscriptionsEntity FindById(Guid id)
        {
            return _db.Find(id);
        }

        public IEnumerable<SubscriptionsEntity> Get()
        {
            return _db.AsNoTracking()
                .ToList();
        }

        public IEnumerable<SubscriptionsEntity> Get(Func<SubscriptionsEntity, bool> predicate)
        {
            return _db.AsNoTracking()
                .Where(predicate)
                .ToList();
        }

        public IEnumerable<SubscriptionsEntity> GetWithInclude(Func<SubscriptionsEntity, bool> predicate,
            params Expression<Func<SubscriptionsEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        public IQueryable<SubscriptionsEntity> Include(params Expression<Func<SubscriptionsEntity, object>>[] includeProperties)
        {
            IQueryable<SubscriptionsEntity> query = _db.AsNoTracking();
            return includeProperties.Aggregate(query,
                (current, includeProperties) =>
                current.Include(includeProperties));
        }

        public int Remove(SubscriptionsEntity entity)
        {
            _db.Remove(entity); 
            return _context.SaveChanges();
        }

        public int Update(SubscriptionsEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}
