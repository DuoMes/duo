using System;

namespace Duo.Notifications
{
    public class SuccessNotification
    {
        public object Result { get; set; }
        public string CorrelationId { get; set; }
        public Type Command { get; set; }
    }

    public class FailureNotification
    {
        public Exception Error { get; set; }
        public string CorrelationId { get; set; }
        public Type Command { get; set; }
    }
}
