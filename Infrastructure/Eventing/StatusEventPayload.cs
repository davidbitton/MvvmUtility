using System;

namespace MvvmUtility.Infrastructure.Eventing {
    public class StatusEventPayload {
        public StatusEventPayload(string status, Exception exception) {
            Status = status;
            Exception = exception;
        }

        public string Status { get; private set; }
        public Exception Exception { get; set; }
    }
}