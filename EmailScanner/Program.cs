using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmailScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            Config configure = new Config();

            configure.readConfigEmailList();
            configure.SearchEmail();
            

        //    FileHandlerFactory factory = new FileHandlerFactory();
    
            //    IFileHandler text = factory.GetFileType(".txt");//filename
           //     text.WriteToFile("test");       //what writes to said file
           //     Console.ReadKey();
            }
        }
    }

