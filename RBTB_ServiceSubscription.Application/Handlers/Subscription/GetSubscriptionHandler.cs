using MediatR;
using RBTB_ServiceSubscription.Application.Abstractions;
using RBTB_ServiceSubscription.Application.Entites;
using RBTB_ServiceSubscription.Application.Requests.Get;
using RBTB_ServiceSubscription.Application.Responses.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Handlers.Subscription
{
    public class GetSubscriptionHandler : IRequestHandler<GetSubscriptionRequest, GetSubscriptionResponse>
    {
        private readonly IRepository<SubscriptionsEntity> _repository;

        public GetSubscriptionHandler(IRepository<SubscriptionsEntity> repository) =>
            _repository = repository;

        public async Task<GetSubscriptionResponse> Handle(GetSubscriptionRequest request, CancellationToken cancellationToken)
        {
            var selectedSubscription = _repository.FindById(request.IdSubscription);
            if (selectedSubscription == null)
            {
                return new GetSubscriptionResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Подписки с указанным Id не существует."
                };
            }

            return new GetSubscriptionResponse
            {
                IsSuccess = true,
                BeginDate = selectedSubscription.BeginDate,
                EndDate = selectedSubscription.EndDate,
                IsActive = selectedSubscription.IsActive,
                SubscriptionType = selectedSubscription.GetSubscriptionTypeName,
                IdUser = selectedSubscription.IdUser
            };
        }
    }
}