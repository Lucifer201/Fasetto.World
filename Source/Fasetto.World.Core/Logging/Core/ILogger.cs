namespace Fasetto.World.Core
{
    /// <summary>
    /// A logger that will handle log message from a <see cref="ILogFactory"/>
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Handle the logged message being passed in
        /// </summary>
        /// <param name="message">The message being logged</param>
        /// <param name="level">The level of this log message</param>
        void Log(string message, LogLevel level);
    }
}
