using MediatR;
using RBTB_ServiceSubscription.Application.Abstractions;
using RBTB_ServiceSubscription.Application.Entites;
using RBTB_ServiceSubscription.Application.Requests.Delete;
using RBTB_ServiceSubscription.Application.Responses.Create;
using RBTB_ServiceSubscription.Application.Responses.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Handlers.Subscription
{
    public class RemoveSubscriptionHandler : IRequestHandler<DeleteSubscriptionRequest, DeleteSubscriptionsResponse>
    {
        private readonly IRepository<SubscriptionsEntity> _repository;

        public RemoveSubscriptionHandler(IRepository<SubscriptionsEntity> repository) =>
            _repository = repository;

        public async Task<DeleteSubscriptionsResponse> Handle(DeleteSubscriptionRequest request, CancellationToken cancellationToken)
        {
            var removableSubscription = _repository.FindById(request.IdSubscription);

            if (removableSubscription == null)
            {
                return new DeleteSubscriptionsResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Подписки с указанным Id не существует."
                };
            }

            _repository.Remove(removableSubscription);
            return new DeleteSubscriptionsResponse
            {
                IsSuccess = true
            };
        }
    }
}
