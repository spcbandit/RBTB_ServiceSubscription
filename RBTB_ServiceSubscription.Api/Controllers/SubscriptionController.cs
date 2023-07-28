using MediatR;
using Microsoft.AspNetCore.Mvc;
using RBTB_ServiceSubscription.Application.Requests.Create;
using RBTB_ServiceSubscription.Application.Requests.Delete;
using RBTB_ServiceSubscription.Application.Requests.Get;
using RBTB_ServiceSubscription.Application.Requests.GetCollection;
using RBTB_ServiceSubscription.Application.Requests.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceSubscription.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionController(IMediator mediator) =>
            _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetSubscriptions()
        {
            var collection = await _mediator.Send(new GetCollectionSubscriptionsRequest());

            return Ok(collection);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSubscription(Guid id)
        {
            var selectedSubscription = await _mediator.Send(new GetSubscriptionRequest(id));
            return selectedSubscription.IsSuccess
                ? Ok(selectedSubscription)
                : BadRequest(selectedSubscription);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionsRequest request)
        {
            var response = await _mediator.Send(request);

            return response.IsSuccess
                ? Ok(response)
                : BadRequest(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateSubscription([FromBody] UpdateSubscriptionsRequest request)
        {
            var response = await _mediator.Send(request);

            return response.IsSuccess
                ? Ok(response)
                : BadRequest(response);
        }

        [HttpDelete]
        [Route("remove")]
        public async Task<IActionResult> RemoveSubscription([FromBody] DeleteSubscriptionRequest request)
        {
            var response = await _mediator.Send(request);

            return response.IsSuccess
                ? Ok(response)
                : BadRequest(response);
        }
    }
}
