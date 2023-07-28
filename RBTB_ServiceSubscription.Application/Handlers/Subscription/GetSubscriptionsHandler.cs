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
        private readonly IRepository<UsersEntity> _userRepository;

        public GetSubscriptionsHandler(IRepository<SubscriptionsEntity> repository, IRepository<UsersEntity> userRepository) =>
            (_repository, _userRepository) = (repository, userRepository);

        public async Task<GetCollectionSubscriptionsResponse> Handle(GetCollectionSubscriptionsRequest request, CancellationToken cancellationToken)
        {
            var selectedUser = _userRepository.FindById(request.IdUser);
            if (selectedUser == null)
            {
                return new GetCollectionSubscriptionsResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Пользователя с указанным Id не существует."
                };
            }

            var subscribtionsCollection = _repository.Get(p => p.IdUser == request.IdUser).ToList()
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
