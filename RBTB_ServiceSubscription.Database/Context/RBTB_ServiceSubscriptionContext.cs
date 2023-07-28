using Microsoft.EntityFrameworkCore;
using RBTB_ServiceSubscription.Application.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Database.Context
{
    public class RBTB_ServiceSubscriptionContext : DbContext
    {
        public DbSet<UsersEntity> Users { get; set; }

        public DbSet<SubscriptionsEntity> Subscriptions { get; set; }

        public RBTB_ServiceSubscriptionContext(DbContextOptions<RBTB_ServiceSubscriptionContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
