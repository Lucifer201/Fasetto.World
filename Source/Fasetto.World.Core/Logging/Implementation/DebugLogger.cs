using System.Diagnostics;

namespace Fasetto.World.Core
{
    /// <summary>
    /// Logs the message to the Debug log
    /// </summary>
    public class DebugLogger : ILogger
    {
        /// <summary>
        /// Log the given message to the system Console
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="level">The level of the message</param>
        public void Log(string message, LogLevel level)
        {
            //The default category
            var category = default(string);

            //NOTE: The native Debug output has no color
            //      However if you install the VS extension VSColorOutput
            //      Then this style will color the outputs nicely
            //
            //      http://github.com/mike-ward/VSColorOutput
            //

            //Color console based on level
            switch (level)
            {
                case LogLevel.Debug:
                    category = "information";
                    break;
                case LogLevel.Verbose:
                    category = "verbose";
                    break;
                case LogLevel.Warning:
                    category = "warning";
                    break;
                case LogLevel.Error:
                    category = "error";
                    break;
                case LogLevel.Success:
                    category = "-----";
                    break;
            }

            //Write message to console
            Debug.WriteLine(message, category);
        }
    }
}
