﻿using System.Threading.Tasks;

namespace Fasetto.World.Core
{
    /// <summary>
    /// Handles reading/writing and querying the file system
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// Writes the text to specified file
        /// </summary>
        /// <param name="text">Text to write</param>
        /// <param name="path">The path of the file to write to</param>
        /// <param name="append">If true, writes the text to the end of the file, otherwise override any existing file</param>
        /// <returns></returns>
        Task WriteTextToFileAsync(string text, string path, bool append = false);

        /// <summary>
        /// Normalizing a path based on the current operating system
        /// </summary>
        /// <param name="path">The path to normalize</param>
        /// <returns></returns>
        string NormalizePath(string path);

        /// <summary>
        /// Resolves any relative elements of the path to absolute
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string ResovePath(string path);

    }
}
