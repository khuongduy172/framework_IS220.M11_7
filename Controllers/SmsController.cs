using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Nexmo.Api.Messaging;
using social_network.Hubs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace social_network.Controllers
{
    public class SmsController : Controller
    {
        public IHubContext<SmsHub> HubContext { get; set; }

        public SmsController(IHubContext<SmsHub> hub)
        {
            HubContext = hub;
        }
        [HttpPost("webhooks/inbound-sms")]
        public async Task<IActionResult> InboundSms()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var json = await reader.ReadToEndAsync();
                var inbound = JsonConvert.DeserializeObject<InboundSms>(json);
                await HubContext.Clients.All.SendAsync("InboundSms", inbound.Msisdn, inbound.Text);
            }
            return NoContent();
        }
    }
}
