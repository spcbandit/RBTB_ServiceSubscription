using MediatR;
using RBTB_ServiceSubscription.Application.Responses.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Requests.Update
{
    public record UpdateSubscriptionsRequest(Guid IdSubscription, int SubscriptionType, DateTime BeginDate, DateTime EndDate, bool IsActive) 
        : IRequest<UpdateSubscriptionResponse>;
}
