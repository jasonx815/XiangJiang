using System;
namespace XiangJiang.Exceptions
{
    [Serializable]
    public sealed class ExceptionMessage
    {
        public readonly string ActualMessage;
        public readonly long ErrorCode;
        public readonly string StackTrace;
        public readonly string UserMessage;

        public ExceptionMessage(string userMessage, string actualMessage, string stackTrace, long errorCode)
        {
            UserMessage = userMessage;
            ActualMessage = actualMessage;
            StackTrace = stackTrace;
            ErrorCode = errorCode;
        }

        public ExceptionMessage()
        {

        }

        public override string ToString()
        {
            return StackTrace;
        }
    }
}