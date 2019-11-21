using SSC.Api.Behavior;
using SSC.Api.ViewModels;
using SSC.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SSC.Api.Controllers
{
    public class ChatCommunicationStatisticsController : ApiController
    {
        public class ChatStatistic
        {
            public DateTime StartDate { get; set; }
            public DateTime StartDateAsDate { get => this.StartDate.Date; }
            public DateTime? ReplyDate { get; set; }
            public int EffectivityPercentage { get; set; } = 100;
            public bool HasReply { get; set; } = false;
        }

        protected int GetEffectivityPercentage(DateTime startDate, DateTime endDate)
        {
            var difference = endDate.Subtract(startDate).TotalMinutes;
            int output;

            if (difference <= 100)
            {
                output = (100 - difference).AsInt();
            }
            else
            {
                output = 1;
            }

            return output;
        }

        public class ChatAverageStatisticByDay
        {
            public DateTime Date { get; set; }
            public int Year { get => this.Date.Year; }
            public int Month { get => this.Date.Month;  }
            public int Day { get => this.Date.Day; }
            public decimal AverageEffectivity { get; set; }
        }

        public class ChatStatisticsViewModel
        {
            public IList<ChatStatistic> SpecificStatistics { get; set; } = new List<ChatStatistic>();
            public IList<ChatAverageStatisticByDay> ByDay { get; set; } = new List<ChatAverageStatisticByDay>();
        }

        public ResponseViewModel<IEnumerable<UserChatViewModel>> Get(int id)
        {
            if (id == -1)
            {
                var userIds = new[] { 3, 4, 5, 6, 7 };
                var daysToPast = 30;

                for (var day = daysToPast; day > 0; day--)
                {
                    var baseDate = DateTime.Now.Subtract(new TimeSpan(day, 0, 0, 0)).Date;

                    foreach (var userId in userIds)
                    {
                        var randomizer = new Random();
                        var messagesToGenerate = 20;
                        var getsReply = randomizer.Next(0, 2) == 0;
                        var currentDate = baseDate;

                        for (var messageIndex = 0; messageIndex < messagesToGenerate; messageIndex++)
                        {
                            var effectivityExpected = randomizer.Next(40, 100);
                            var replyDate = currentDate.AddMinutes(100 - effectivityExpected);

                            var question = new ChatMessageViewModel
                            {
                                AuthorId = userId,
                                AuthorName = String.Format("fakeUser-{0}", userId),
                                CreatedDate = currentDate,
                                Content = "Fake question",
                                IsMine = true,
                                Pending = true
                            };

                            PlatformChatMessageCache.Add(question, userId);

                            var reply = new ChatMessageViewModel
                            {
                                AuthorId = 1,
                                AuthorName = "admin@ssc.com",
                                CreatedDate = replyDate,
                                Content = "Fake reply",
                                IsMine = false
                            };

                            PlatformChatMessageCache.Add(reply, userId);

                            currentDate = replyDate.AddMinutes(2);
                        }
                    }
                }

            }

            return PlatformChatMessageCache.GetAll().ToList();
        }

        public ResponseViewModel<ChatStatisticsViewModel> Get()
        {
            var output = new ChatStatisticsViewModel();
            var allStatistics = new List<ChatStatistic>();
            var chats = PlatformChatMessageCache.GetAll();

            foreach (var chat in chats)
            {
                var queue = new Queue<ChatMessageViewModel>(chat.Messages.ToList());

                while (queue.Any())
                {
                    var msg = queue.Dequeue();

                    if (msg.IsMine)
                    {
                        var statistic = new ChatStatistic { StartDate = msg.CreatedDate };

                        while (queue.Any())
                        {
                            var reply = queue.Dequeue();

                            if (!reply.IsMine)
                            {
                                statistic.HasReply = true;
                                statistic.EffectivityPercentage = this.GetEffectivityPercentage(statistic.StartDate, reply.CreatedDate);
                                statistic.ReplyDate = reply.CreatedDate;

                                break;
                            }
                        }

                        if (!statistic.HasReply)
                        {
                            statistic.EffectivityPercentage = this.GetEffectivityPercentage(statistic.StartDate, DateTime.Now);
                        }

                        allStatistics.Add(statistic);
                    }
                }
            }

            // Ordenamos por fecha las estadisticas fijas
            foreach (var stat in allStatistics.OrderBy(x => x.StartDate))
            {
                output.SpecificStatistics.Add(stat);
            }

            // Generamos estadisticas por cada dia
            foreach (var dayGroup in allStatistics.OrderBy(x => x.StartDateAsDate).GroupBy(x => x.StartDateAsDate))
            {
                var avgStat = new ChatAverageStatisticByDay();
                avgStat.Date = dayGroup.Key;
                avgStat.AverageEffectivity = Math.Round(dayGroup.Average(x => x.EffectivityPercentage.AsDouble()), 2).AsDecimal();

                output.ByDay.Add(avgStat);
            }

            return output;
        }
    }
}