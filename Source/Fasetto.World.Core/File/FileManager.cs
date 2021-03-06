﻿using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Fasetto.World.Core
{
    public class FileManager: IFileManager
    {

        /// <summary>
        /// Writes the text to specified file
        /// </summary>
        /// <param name="text">Text to write</param>
        /// <param name="path">The path of the file to write to</param>
        /// <param name="append">If true, writes the text to the end of the file, otherwise override any existing file</param>
        /// <returns></returns>
        public async Task WriteTextToFileAsync(string text, string path, bool append = false)
        {
            //TODO: Add exception catching

            //Normalize path
            path = NormalizePath(path);

            //Resolve to absolute path
            path = ResovePath(path);

            //Lock the task
            await AsyncAwaiter.AwaitAsync(nameof(FileManager) + path, async () =>
            {
                //Runs the synchronous file access as a new task
                await IoC.Task.Run(() =>
                {
                    //Write the log message to file 
                    using (var fileStream = (TextWriter)new StreamWriter(File.Open(path, append ? FileMode.Append : FileMode.Create)))
                        fileStream.Write(text);
                });


            });
        }


        /// <summary>
        /// Normalizing a path based on the current operating system
        /// </summary>
        /// <param name="path">The path to normalize</param>
        /// <returns></returns>
        public string NormalizePath(string path)
        {
            //If on Windows...
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                //Replace any / with \
                return path?.Replace('/', '\\');
            //If on Linux/Mac
            else
                //Replace any \ with /
                return path?.Replace('\\', '/');
        }

        /// <summary>
        /// Resolves any relative elements of the path to absolute
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ResovePath(string path)
        {
            //Resolve the path to absolute
            return Path.GetFullPath(path);
        }
    }
}
