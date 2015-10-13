using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace EmailScanner
{   

    public interface IFileHandler
    {
        void WriteToFile(string individualSearchTerm, string to, string from, string subject, string individualEmailSentence, string name);
    }
    public class Txt : IFileHandler
    {
        public void WriteToFile(string individualSearchTerm, string to, string from, string subject, string individualEmailSentence, string name)
        {
            System.IO.File.AppendAllText((name), "Search Term: " + individualSearchTerm + "\r\n" + to + "\r\n" + from + "\r\n" + subject + "\r\n" + "Containing Sentence: " + individualEmailSentence + "\r\n\r\n");
              
        }
    }
    public class Csv : IFileHandler
    {
        public void WriteToFile(string individualSearchTerm, string to, string from, string subject, string individualEmailSentence, string name)
        {
            System.IO.File.AppendAllText((name), "Search Term, " + individualSearchTerm + ", " + to + ", " + from + ", " + subject + ", " + "Containing Sentence, " + individualEmailSentence + "\r\n");
        }
    }
    public class Xml : IFileHandler
    {
        public void WriteToFile(string individualSearchTerm, string to, string from, string subject, string individualEmailSentence, string name)
        {
            System.IO.File.AppendAllText((name), "<Email>\r\n  <SearchTerm>" + individualSearchTerm + "</SearchTerm>" + "\r\n  <to>" + to + "</to>\r\n  <from>" + from + "</from>\r\n  <subject>" + subject + "</subject>\r\n  <ContainingSentence>" + individualEmailSentence + "</ContainingSentence>\r\n<Email> \r\n\r\n");
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