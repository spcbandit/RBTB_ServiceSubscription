using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Responses.GetCollection
{
    public class GetCollectionSubscriptionsResponse : BaseResponse
    {
        public IEnumerable<GetCollectionSubscriptionsId> Subscriptions { get; set; }
    }

    public class GetCollectionSubscriptionsId
    {
        public Guid IdSubscription { get; set; }
    }
}
