using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmailScanner
{   

    public interface IFileHandler
    {
        void WriteToFile(string content, string name);
    }
    public class Txt : IFileHandler
    {
        public void WriteToFile(string content, string name)
        {
              System.IO.File.AppendAllText((name), content);
              
        }
    }
    public class Csv : IFileHandler
    {
        public void WriteToFile(string content, string name)
        {
            System.IO.File.AppendAllText((name), content);
        }
    }
    public class Xml : IFileHandler
    {
        public void WriteToFile(string content, string name)
        {
            System.IO.File.AppendAllText((name), content);
        }
    }
   public class FileHandlerFactory 
    {
        public IFileHandler GetFileType(string fileExtension)
        {     
            switch (fileExtension)
            {
                case "txt":                 
                   return new Txt();               
                case "csv":
                   return new Csv();
                case "xml":
                   return new Xml();
                default:
                   throw new ApplicationException(string.Format("Log file '{0}' cannot be created", fileExtension));                  
            }
        }
    }
}