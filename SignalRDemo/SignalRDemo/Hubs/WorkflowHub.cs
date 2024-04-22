using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.SignalR;
using static SignalRDemo.Client.Pages.Tasks;

namespace SignalRDemo.Hubs
{
    public class WorkflowHub : Hub
    {
        public async Task ReviewApplication(long taskId)
        {
            await Clients.All.SendAsync("applicationReviewed", taskId);
        }

        public async Task CreateApplication(bool test)
        {
            await Clients.All.SendAsync("applicationCreated", test);
        }
    }
}
