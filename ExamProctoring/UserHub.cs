using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace ExamProctoring
{
    public class UserHub : Hub
    {
        public async Task GetOnlineAsync(string name, string status)
        {
            Clients.All.SendAsync("getOnlineUsers", name);
        }
    }
}