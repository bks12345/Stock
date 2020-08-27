using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Stock.BLL.Common;
using Newtonsoft.Json;

namespace Stock
{
    public class MyHub : Hub
    {
        #region Data Members

        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();

        #endregion

        #region Methods

        public void Connect(string userName, int userId)
        {
            var id = userId.ToString();// Context.ConnectionId;


            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserName = userName });

                // send to caller
                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }


        }
        public List<UserDetail> GetAllActiveConnections()
        {
            return ConnectedUsers.ToList();
        }

        public void Disconnect(string userName, int userId)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == userId.ToString());
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = userId.ToString();
                //Clients.All.onUserDisconnected(id, item.UserName, ConnectedUsers);

            }
        }
        //public void SendMessageToAll(string userName, string message)
        //{
        //    // store last 100 messages in cache
        //    AddMessageinCache(userName, message);

        //    // Broad cast message
        //    Clients.All.messageReceived(userName, message);
        //}

        //public void SendPrivateMessage(string toUserId, string message)
        //{

        //    string fromUserId = Context.ConnectionId;

        //    var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
        //    var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

        //    if (toUser != null && fromUser != null)
        //    {
        //        // send to 
        //        Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message);

        //        // send to caller user
        //        Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
        //    }

        //}

        public override System.Threading.Tasks.Task OnDisconnected(Boolean stopCalled)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName, ConnectedUsers);

            }

            return base.OnDisconnected(false);
        }


        #endregion

        #region private Messages

        private void AddMessageinCache(string userName, string message)
        {
            CurrentMessage.Add(new MessageDetail { UserName = userName, Message = message });

            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);
        }

        #endregion
        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.displayStatus();

        }

        public void NotifyAllClients(string msg)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.displayNotification(msg);
        }
    }
}