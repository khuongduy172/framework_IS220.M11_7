using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace social_network.Controllers
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(Message message);
    }
}
