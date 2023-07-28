using MediatR;
using RBTB_ServiceSubscription.Application.Abstractions;
using RBTB_ServiceSubscription.Application.Entites;
using RBTB_ServiceSubscription.Application.Requests.GetCollection;
using RBTB_ServiceSubscription.Application.Responses.GetCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Handlers.Subscription
{
    public class GetSubscriptionsHandler : IRequestHandler<GetCollectionSubscriptionsRequest, GetCollectionSubscriptionsResponse>
    {
        private readonly IRepository<SubscriptionsEntity> _repository;

        public GetSubscriptionsHandler(IRepository<SubscriptionsEntity> repository) =>
            _repository = repository;

        public async Task<GetCollectionSubscriptionsResponse> Handle(GetCollectionSubscriptionsRequest request, CancellationToken cancellationToken)
        {
            var subscribtionsCollection = _repository.Get().ToList()
                .Select(p => new GetCollectionSubscriptionsId
                {
                    IdSubscription = p.Id
                });

            return new GetCollectionSubscriptionsResponse
            {
                IsSuccess = true,
                Subscriptions = subscribtionsCollection
            };
        }
    }
}
