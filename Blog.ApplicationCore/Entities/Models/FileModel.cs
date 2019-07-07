using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Blog.ApplicationCore.Entities
{
    public class FileModel
    {
        public MemoryStream File { get; set; }

        public string Id { get; set; }

        public string ContentType { get; set; }

        public FileModel()
        {
        }
    }
}
