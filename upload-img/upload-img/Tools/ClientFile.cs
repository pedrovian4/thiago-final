using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace upload_img.Tools
{
    public class ClientFile
    {
        public static string CreateLocal(IFormFile file, int id)
        {
            string caminho = null;
            var PathCompleto = $"Images/{id}/";

            if (!Directory.Exists(PathCompleto))
                Directory.CreateDirectory(PathCompleto);

            var stream = System.IO.File.Create(PathCompleto + file.FileName);
            file.CopyTo(stream);
            stream.Close();
            caminho = $"Images/{id}/{file.FileName}";

            return caminho;
        }
    }
}
