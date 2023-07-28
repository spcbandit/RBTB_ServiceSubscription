using MediatR;
using RBTB_ServiceSubscription.Application.Abstractions;
using RBTB_ServiceSubscription.Application.Entites;
using RBTB_ServiceSubscription.Application.Requests.Update;
using RBTB_ServiceSubscription.Application.Responses.Get;
using RBTB_ServiceSubscription.Application.Responses.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Handlers.Subscription
{
    public class UpdateSubscriptionHandler : IRequestHandler<UpdateSubscriptionsRequest, UpdateSubscriptionResponse>
    {
        private readonly IRepository<SubscriptionsEntity> _repository;

        public UpdateSubscriptionHandler(IRepository<SubscriptionsEntity> repository) =>
            _repository = repository;

        public async Task<UpdateSubscriptionResponse> Handle(UpdateSubscriptionsRequest request, CancellationToken cancellationToken)
        {
            var selectedSubscription = _repository.FindById(request.IdSubscription);
            if (selectedSubscription == null)
            {
                return new UpdateSubscriptionResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Подписки с указанным Id не существует."
                };
            }

            selectedSubscription.Type = (SubscriptionsType)request.SubscriptionType;
            selectedSubscription.BeginDate = request.BeginDate;
            selectedSubscription.EndDate = request.EndDate;
            selectedSubscription.IsActive = request.IsActive;

            _repository.Update(selectedSubscription);
            return new UpdateSubscriptionResponse
            {
                IsSuccess = true
            };
        }
    }
}
