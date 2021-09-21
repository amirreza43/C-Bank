using System;
using System.Collections.Generic;

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

    }
}