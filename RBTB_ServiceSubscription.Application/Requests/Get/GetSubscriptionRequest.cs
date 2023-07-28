using MediatR;
using RBTB_ServiceSubscription.Application.Responses.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Requests.Get
{
    public record GetSubscriptionRequest(Guid IdSubscription) : IRequest<GetSubscriptionResponse>;
}
