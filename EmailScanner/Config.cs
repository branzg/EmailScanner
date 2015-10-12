﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace EmailScanner
{
    class Config
    {
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

                            foreach (string individualEmailSentence in emailSentences)
                                foreach (string individualSearchTerm in searchTermsOnThisLine)
                                    if (individualEmailSentence.Contains(individualSearchTerm))
                                    {                                  
                                        System.IO.File.AppendAllText(configFileName, "Search Term:" + individualSearchTerm + "\n" + to + "\n" + from + "\n" + subject + "\n" + "Containing Sentence: " + individualEmailSentence + "\n\n");                                    
                                    }
                        }
                }          
            }
        }
    }  
}
