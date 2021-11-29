using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace social_network.Controllers
{
    public class NotifyHub : Hub<ITypedHubClient>
    {
    }
}
