using MediatR;
using RBTB_ServiceSubscription.Application.Responses.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Requests.Create
{
    public record CreateSubscriptionsRequest(int SubscriptionType, DateTime BeginDate, DateTime EndDate, bool IsActive, Guid IdUser)
        : IRequest<CreateSubscriptionsResponse>;
}
