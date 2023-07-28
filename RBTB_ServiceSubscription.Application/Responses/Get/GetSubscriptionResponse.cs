using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Responses.Get
{
    public class GetSubscriptionResponse : BaseResponse
    {
        public string SubscriptionType { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public Guid IdUser { get; set; }
    }
}
