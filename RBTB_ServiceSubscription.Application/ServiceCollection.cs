using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application
{
    public static class ServiceCollection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(ServiceCollection).GetTypeInfo().Assembly;
            services.AddMediatR(assembly);
        }
    }
}
