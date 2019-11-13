using SSC.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSC.Api.Behavior
{
    public class PlatformChatMessageCache
    {
        private static readonly object locker = new object();
        private static readonly IDictionary<int, UserChatViewModel> dict = new Dictionary<int, UserChatViewModel>();

        public static void Add(ChatMessageViewModel message, int userId)
        {
            lock (locker)
            {
                if (dict.ContainsKey(userId))
                {
                    var model = dict[userId];
                    model.Messages.Add(message);

                    if (model.Messages.Count > 30)
                    {
                        model.Messages = model.Messages.Take(30).ToList();
                    }
                }
                else
                {
                    var userChat = new UserChatViewModel();
                    userChat.Messages.Add(message);

                    dict.Add(userId, userChat);
                }
            }
        }

        public static IEnumerable<UserChatViewModel> GetAll()
        {
            return dict.Values.ToList();
        }

        public static IEnumerable<ChatMessageViewModel> Get(int userId)
        {
            if (dict.ContainsKey(userId))
            {
                var chat = dict[userId];
                var countToTake = Math.Max(chat.Messages.Count, 30);
                return chat.Messages.Reverse().Take(countToTake).Reverse();
            }

            return new List<ChatMessageViewModel>();
        }
    }
}