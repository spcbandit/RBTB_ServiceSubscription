using MediatR;
using RBTB_ServiceSubscription.Application.Abstractions;
using RBTB_ServiceSubscription.Application.Entites;
using RBTB_ServiceSubscription.Application.Requests.Create;
using RBTB_ServiceSubscription.Application.Responses.Create;

namespace RBTB_ServiceSubscription.Application.Handlers.Subscription
{
    public class CreateSubscriptionHandler : IRequestHandler<CreateSubscriptionsRequest, CreateSubscriptionsResponse>
    {
        private readonly IRepository<SubscriptionsEntity> _repository;
        private readonly IRepository<UsersEntity> _users;

        public CreateSubscriptionHandler(IRepository<SubscriptionsEntity> repository, IRepository<UsersEntity> users) =>
            (_repository, _users) = (repository, users);
        public async Task<CreateSubscriptionsResponse> Handle(CreateSubscriptionsRequest request, CancellationToken cancellationToken)
        {
            if (_users.FindById(request.IdUser) == null)
            {
                return new CreateSubscriptionsResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Пользователя с указанным Id не существует."
                };
            }

            var newSubscribtion = new SubscriptionsEntity
            {
                IdUser = request.IdUser,
                BeginDate = request.BeginDate,
                EndDate = request.EndDate,
                IsActive = request.IsActive,
                Type = (SubscriptionsType)request.SubscriptionType
            };
            _repository.Create(newSubscribtion);

            return new CreateSubscriptionsResponse
            {
                IsSuccess = true,
                IdSubscription = newSubscribtion.Id.ToString()
            };
        }
    }
}
