using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RBTB_ServiceSubscription.Application.Abstractions;
using RBTB_ServiceSubscription.Application.Entites;
using RBTB_ServiceSubscription.Database.Context;
using RBTB_ServiceSubscription.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionsRepository = RBTB_ServiceSubscription.Database.Repository.SubscriptionsRepository;

namespace RBTB_ServiceSubscription.Database
{
    public static class ServiceCollection
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("RBTB_ServiceSubscription_ConnectionString");
            services.AddDbContext<RBTB_ServiceSubscriptionContext>(options=> options.UseNpgsql(connection));
            services.AddTransient<IRepository<UsersEntity>, UsersRepository>();
            services.AddTransient<IRepository<SubscriptionsEntity>, SubscriptionsRepository>();
        }
    }
}
