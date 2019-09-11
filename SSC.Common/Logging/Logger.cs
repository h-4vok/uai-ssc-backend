using SSC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common.Logging
{
    public class Logger
    {
        #region Singleton

        private Logger() { }
        static Logger() { }

        public static Logger Obj { get; } = new Logger();

        #endregion

        private IList<LoggerSubscriber> subscribers = new List<LoggerSubscriber>();

        public void AddSubscriber(LoggerSubscriber subscriber) => subscribers.Add(subscriber);

        public void RemoveSubscriber(LoggerSubscriber subscriber) => subscribers.Remove(subscriber);

        public void RemoveAllSubscribers() => subscribers.Clear();

        internal IEnumerable<LoggerSubscriber> GetAllSubscribers() => subscribers.ToList();

        private string GetCurrentUserName()
        {
            var auth = DependencyResolver.Obj.Resolve<IAuthenticationProvider>();
            return auth.CurrentUserName;
        }

        private string FormatExceptionMessage(Exception ex)
        {
            const string format = "Error '{1}' - Source '{2}' - Message '{3}'{0}" +
                "Stack Trace:{0}" +
                "{4}";
            var message =
                string.Format(
                    format,
                    System.Environment.NewLine, 
                    ex.GetType().FullName, 
                    ex.Source, 
                    ex.Message, 
                    ex.StackTrace);

            return message;
        }

        public void LogInfo(string message)
        {
            this.subscribers.ForEach(s => s.NotifyInformation(this.GetCurrentUserName(), message));
        }

        public void LogError(string message)
        {
            this.subscribers.ForEach(s => s.NotifyError(this.GetCurrentUserName(), message));
        }

        public void LogException(Exception ex)
        {
            var message = this.FormatExceptionMessage(ex);
            this.LogError(message);
        }
     }
}
