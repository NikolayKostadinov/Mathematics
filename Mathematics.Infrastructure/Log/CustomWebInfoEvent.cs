namespace Mathematics.Infrastructure.Log
{
    using System.Web.Management;

    class CustomWebInfoEvent : WebApplicationLifetimeEvent
    {
        public CustomWebInfoEvent(string msg, object eventSource, int eventCode)
            : base(msg, eventSource, eventCode)
        {

        }
    }
}
