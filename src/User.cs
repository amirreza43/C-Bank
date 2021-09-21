using System;
using System.Collections.Generic;

namespace CBank
{
    public class User : Bank{
      public string name;
      public List<string> userLogs= new List<string>();
      public bool hasChecking=false;
      public bool hasSavings=false;
    }
}