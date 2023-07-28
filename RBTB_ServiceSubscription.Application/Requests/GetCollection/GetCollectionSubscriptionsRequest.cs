using MediatR;
using RBTB_ServiceSubscription.Application.Responses.GetCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Requests.GetCollection
{
    public record GetCollectionSubscriptionsRequest(Guid IdUser) : IRequest<GetCollectionSubscriptionsResponse>;
}
