using System;
using System.Text;
using XiangJiang.Core;
using XiangJiang.Exceptions;

namespace XiangJiang.Common
{
    public static class ExceptionHelper
    {
        public static ExceptionMessage Format(this Exception exception, string userMessage = null,
            bool isHideStackTrace = false, long errorCode = 0)
        {
            Checker.Begin().NotNull(exception, nameof(exception));
            userMessage = string.IsNullOrEmpty(userMessage) ? exception.Message : userMessage;
            var builder = new StringBuilder();
            var actualMessage = string.Empty;
            while (exception != null)
            {
                actualMessage = exception.Message;
                builder.AppendLine($"Message:{exception.Message}");
                builder.AppendLine($"Type:{exception.GetType().FullName}");
                builder.AppendLine(
                    $"Method:{(exception.TargetSite == null ? null : exception.TargetSite.Name)}");
                builder.AppendLine($"Source:{exception.Source}");
                if (!isHideStackTrace && exception.StackTrace != null)
                    builder.AppendLine($"StackTrace:{exception.StackTrace}");
                if (exception.InnerException != null)
                    builder.AppendLine($"InnerException:{exception.InnerException.Message}");
                exception = exception.InnerException;
            }
            var stackTrace = builder.ToString();
            builder.Clear();
            return new ExceptionMessage(userMessage, actualMessage, stackTrace, errorCode);
        }
    }
}