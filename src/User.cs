using System;
using System.Collections.Generic;
using System.IO;

namespace CBank
{
    public class User{
      public string name;
      public List<string> userLogs= new List<string>();
      public bool hasChecking = false;
      public bool hasSavings = false;

      public void WriteLogs(){

        foreach( var log in userLogs ){

          Console.WriteLine(log);

        }

      }

      public void WriteToFile(){
        

        string path = @"C:\Bootcamp\C#\Day 2\C-Bank\myFile.csv";

        // Set the variable "delimiter" to ", ".
        string delimiter = ", ";

        // This text is added only once to the file.
        if (!File.Exists(path))
        {         
            // Create a file to write to.
            string createText = "User" + delimiter 
            + "Account Type" + delimiter 
            + "Date" + delimiter 
            + "Transaction Type" + delimiter
            + "Amount" + delimiter 
            + "Success or Failure" + delimiter 
            + "Balance" + delimiter 
            + "Account Status"
            + Environment.NewLine;
            File.WriteAllText(path, createText); 

        }

        foreach( var log in userLogs){

          string[] logInfo = log.Split(", ");

          string appendText = logInfo[0] + delimiter + logInfo[1] + delimiter + logInfo[2] + delimiter 
          + logInfo[3] + delimiter 
          + logInfo[4] + delimiter 
          + logInfo[5] + delimiter 
          + logInfo[6] + delimiter 
          + logInfo[7] + delimiter 
          + Environment.NewLine;
          File.AppendAllText(path, appendText);

        }


        
      }

    }
}