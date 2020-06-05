using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Fasetto.World.Core
{
    /// <summary>
    /// The standard log factory for Fasetto.World
    /// Logs details to Console by default           
    /// </summary>
    public class BaseLogFactory : ILogFactory
    {
        #region Protected Methods

        /// <summary>
        /// The list of loggers in this LogFactory
        /// </summary>
        protected List<ILogger> mLoggers = new List<ILogger>();

        /// <summary>
        /// A lock for the list to keep it thread-safe
        /// </summary>
        protected object mLoggerLock = new object();

        #endregion

        #region Public Properties

        /// <summary>
        /// The level of logging to output
        /// </summary>
        public LogOutputLevel LogOutputLevel { get; set; }

        /// <summary>
        /// If true, includes the origin of where the log message was logged from
        /// such as the class name, line number and file name
        /// </summary>
        public bool IncludeLogOriginDetails { get; set; } = true;

        #endregion

        #region Public Events

        /// <summary>
        /// Fires whenever a new log arrives
        /// </summary>
        public event Action<(string Message, LogLevel Level)> NewLog = (details) => { };

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="loggers">The loggers to add to the factory, on top of the stock loggers</param>
        public BaseLogFactory(ILogger[] loggers=null)
        {
            //Add console logger
            AddLogger(new DebugLogger());

            //Add any others passed in
            if (loggers != null)
                foreach (var logger in loggers)
                    AddLogger(logger);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add the specific logger to this factory
        /// </summary>
        /// <param name="logger">The logger</param>
        public void AddLogger(ILogger logger)
        {
            //Log the list so it is thread-safe
            lock (mLoggerLock)
            {
                //If the logger is not in the list
                if (!mLoggers.Contains(logger))
                    //Add the logger to the list
                    mLoggers.Add(logger);
            }
        }

        /// <summary>
        /// Remove the specified logger from this factory
        /// </summary>
        /// <param name="logger">The logger</param>
        public void RemoveLogger(ILogger logger)
        {
            //Log the list so it is thread-safe
            lock (mLoggerLock)
            {
                //If the logger is in the list
                if (mLoggers.Contains(logger))
                    //Remove the logger out of the list
                    mLoggers.Remove(logger);
            }
        }

        /// <summary>
        /// Logs the specific message to all loggers in this factory
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="level">The level of the message being logged</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line number of code in the filename this message was logged from</param>
        public void Log(string message,
            LogLevel level = LogLevel.Informative,
            [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            //If we should not log the message as the level is too low...
            if ((int)level < (int)LogOutputLevel)
                return;

            //If the user wants to know where the log originated from...
            if (IncludeLogOriginDetails)
                message = $"{message}[{Path.GetFileName(filePath)} > {origin}() > Line {lineNumber}]";

            //Log the list so it is thread-safe
            lock (mLoggerLock)
            {
                //Log to all loggers
                mLoggers.ForEach(logger => logger.Log(message, level));
            }

            //Inform listeners
            NewLog.Invoke((message, level));
        }



        #endregion
    }
}
