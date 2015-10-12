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
        void WriteToFile(string content);
    }
    public class Txt : IFileHandler
    {
        public void WriteToFile(string content)
        {
              System.IO.File.AppendAllText(("log.txt"), content); 
        }
    }
    public class Csv : IFileHandler
    {
        public void WriteToFile(string content)
        {
            System.IO.File.AppendAllText(("log.csv"), content);
        }
    }
    public class Xml : IFileHandler
    {
        public void WriteToFile(string content)
        {
            System.IO.File.AppendAllText(("log.xml"), content);
        }
    }
   public class FileHandlerFactory 
    {
        public IFileHandler GetFileType(string filename)
        {     
            switch (filename)
            {
                case ".txt":                 
                   return new Txt();               
                case "log.csv":
                   return new Csv();
                case ".xml":
                   return new Xml();
                default:
                   throw new ApplicationException(string.Format("Log file '{0}' cannot be created", filename));                  
            }
        }
    }
}