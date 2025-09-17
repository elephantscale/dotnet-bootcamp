using System;
using System.IO;
using Lab2_4.Exceptions;

namespace Lab2_4.Models
{
    public class FileProcessor
    {
        public string ReadAllText(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ValidationException("File path is required.")
                {
                    Errors = new System.Collections.Generic.Dictionary<string, string[]>
                    {
                        ["Path"] = new[] { "Path must not be null or whitespace." }
                    }
                };
            }

            if (path.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
                throw new FileProcessingException("Path contains invalid characters.", path);

            try
            {
                return File.ReadAllText(path);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Signature (message, filePath, Exception)
                throw new FileProcessingException("Access denied while reading file.", path, ex);
            }
            catch (IOException ex)
            {
                throw new FileProcessingException("I/O error while reading file.", path, ex);
            }
        }

        public void WriteAllText(string path, string contents)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ValidationException("File path is required.")
                {
                    Errors = new System.Collections.Generic.Dictionary<string, string[]>
                    {
                        ["Path"] = new[] { "Path must not be null or whitespace." }
                    }
                };
            }

            try
            {
                File.WriteAllText(path, contents);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new FileProcessingException("Access denied while writing file.", path, ex);
            }
            catch (IOException ex)
            {
                throw new FileProcessingException("I/O error while writing file.", path, ex);
            }
        }
    }
}