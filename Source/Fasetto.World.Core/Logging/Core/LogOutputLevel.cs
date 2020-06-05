namespace Fasetto.World.Core
{
    /// <summary>
    /// The level of details to output for a logger
    /// </summary>
    public enum LogOutputLevel
    {
        /// <summary>
        /// Logs evertything
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Log all information except debug information
        /// </summary>
        Verbose = 2,

        /// <summary>
        /// Logs all informative messages, ignore any debug and verbose messages
        /// </summary>
        Informative = 3,

        /// <summary>
        /// Log only critical errors, warnings and success,but no general information
        /// </summary>
        Critical = 4,

        /// <summary>
        /// The logger will never output anything
        /// </summary>
        Nothing = 7, 
    }
}
