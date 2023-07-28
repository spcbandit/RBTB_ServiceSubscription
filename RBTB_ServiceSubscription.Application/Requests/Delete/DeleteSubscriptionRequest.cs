using MediatR;
using RBTB_ServiceSubscription.Application.Responses.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Requests.Delete
{
    public record DeleteSubscriptionRequest(Guid IdSubscription) : IRequest<DeleteSubscriptionsResponse>;
}
