using System;
using System.Runtime.CompilerServices;

namespace Fasetto.World.Core
{
    public interface ILogFactory
    {
        #region Events

        /// <summary>
        /// Fires whenever a new log arrives
        /// </summary>
        event Action<(string Message, LogLevel Level)> NewLog;

        #endregion

        #region Properties

        /// <summary>
        /// The level of loggin to output
        /// </summary>
        LogOutputLevel LogOutputLevel { get; set; }

        /// <summary>
        /// If true, includes the origin of where the log message was logged from
        /// such as the class name, line number and file name
        /// </summary>
        bool IncludeLogOriginDetails { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Add the specific logger to this factory
        /// </summary>
        /// <param name="logger">The logger</param>
        void AddLogger(ILogger logger);

        /// <summary>
        /// Remove the specified logger from this factory
        /// </summary>
        /// <param name="logger">The logger</param>
        void RemoveLogger(ILogger logger);

        /// <summary>
        /// Logs the specific message to all loggers in this factory
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="level">The level of the message being logged</param>
        /// <param name="origin">The method/funcion this message was logged in</param>
        /// <param name="filePath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the filename this message was logged from</param>
        void Log(string message, LogLevel level = LogLevel.Informative, [CallerMemberName]string origin = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0);

        #endregion

    }
}
