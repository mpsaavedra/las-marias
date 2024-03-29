﻿using System;
using System.Diagnostics;
using System.Text;

namespace Orun.Extensions
{
    /// <summary>
    /// Exception extensions
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Get exception message
        /// </summary>
        /// <param name="exception">exception to get message</param>
        /// <returns>exception message | ApplicationException: parameter is null</returns>
        public static string Message(this Exception exception)
        {
            var validException = exception.IsNullOrEmpty(nameof(exception));

            return validException.InnerException is null
                ? validException.Message
                : validException.Message + "\n\n --> " + validException.InnerException;
        }

        /// <summary>
        /// Gets a full message from the exception
        /// </summary>
        /// <param name="exception">exception to get message to</param>
        /// <returns>Exception full message</returns>
        public static string FullMessage(this Exception exception)
        {
            var validException = exception.IsNullOrEmpty(nameof(exception));

            var sb = new StringBuilder();

            sb.Append($"Error: {validException.Message()} |");

            var stackFrame = new StackTrace(validException, true)?.GetFrame(0);

            var declaringType = stackFrame?.GetMethod()?.DeclaringType;

            if (!string.IsNullOrWhiteSpace(declaringType?.FullName))
            {
                sb.Append($" File: {declaringType.FullName} |");
            }

            var fileLineNumber = stackFrame?.GetFileLineNumber();

            if (fileLineNumber.HasValue)
            {
                sb.Append($" Line: {fileLineNumber.Value}");
            }

            return sb.ToString();
        }
    }
}