using System;

namespace Fasetto.World.Core
{
    /// <summary>
    /// Logs the message to the Console
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Log the given message to the system Console
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="level">The level of the message</param>
        public void Log(string message, LogLevel level)
        {
            ////Save old color
            var consoleOldColor = Console.ForegroundColor;

            ////Default log color value
            ConsoleColor consoleColor = ConsoleColor.White;

            //Color console based on level
            switch (level)
            {
                case LogLevel.Debug:
                    consoleColor = ConsoleColor.Blue;
                    break;
                case LogLevel.Verbose:
                    consoleColor = ConsoleColor.Gray;
                    break;
                case LogLevel.Informative:
                    consoleColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Warning:
                    consoleColor = ConsoleColor.DarkYellow;
                    break;
                case LogLevel.Error:
                    consoleColor = ConsoleColor.Red;
                    break;
                case LogLevel.Success:
                    consoleColor = ConsoleColor.Green;
                    break;
            }

            ////Set the desired color
            Console.ForegroundColor = consoleColor;

            //Write the message to Console
            Console.WriteLine(message);

            ////Reset the color
            Console.ForegroundColor = consoleOldColor;

            
        }
    }
}
