using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();

            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var result = newPath(file);
            File.Move(sourcepath, result);
            return result;
        }
        public static string Update(string curentpath,IFormFile file)
        {
            var result = newPath(file);

            if (curentpath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(curentpath);
            return result;
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }
        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;
            string path = Environment.CurrentDirectory + @"\Images";
            string newPath = Guid.NewGuid().ToString() + fileExtension;

            var result = $@"{path}\{newPath}";
            return result;
        }
    }
}
