using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Application.Responses
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
