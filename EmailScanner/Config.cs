using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace EmailScanner
{
    class Config
    {
        FileHandlerFactory factory = new FileHandlerFactory();
        string[] configFileLines = System.IO.File.ReadAllLines("EmailScanner.cfg");
        List<string> emailNamesList = new List<string>();
        public void readConfigEmailList()
        {
            string emailLine = configFileLines[0];
            string[] emailNames = emailLine.Split(' ');
            foreach (string individualEmailName in emailNames)
            {
                emailNamesList.Add(individualEmailName);
            }
        }
        public void SearchEmail()
        {      
            for (int currentEmail = 0; currentEmail < emailNamesList.Count; currentEmail++)
            {             
                string emailname = emailNamesList[currentEmail];
                string[] emailLines = System.IO.File.ReadAllLines(emailname);
                string to = emailLines[0];
                string from = emailLines[1];
                string subject = emailLines[2];

                for (int emailLineNumber = 0; emailLineNumber < emailLines.Length; emailLineNumber++)
                {
                    string currentLine = emailLines[emailLineNumber];
                    string[] emailSentences = currentLine.Split('.');
                       
                        for (int configFileLineNumber = 1; configFileLineNumber < configFileLines.Length; configFileLineNumber++)
                        {
                            string configLine = configFileLines[configFileLineNumber];
                            string[] wordsOnThisLine = configLine.Split(' ');
                            var searchTermsOnThisLine = wordsOnThisLine.Skip(1);
                            string configFileName = wordsOnThisLine.First();

                            Match ex = Regex.Match(configFileName, ".{3}$");
                            string extension = Convert.ToString(ex);


                            foreach (string individualEmailSentence in emailSentences)
                                foreach (string individualSearchTerm in searchTermsOnThisLine)
                                    if (individualEmailSentence.Contains(individualSearchTerm))
                                    {                                                              
                                        IFileHandler text = factory.GetFileType(extension);
                                        text.WriteToFile("Search Term: " + individualSearchTerm + "\r\n" + to + "\r\n" + from + "\r\n" + subject + "\r\n" + "Containing Sentence: " + individualEmailSentence + "\r\n\r\n", configFileName);
                                    }
                        }
                }          
            }
        }
    }  
}
