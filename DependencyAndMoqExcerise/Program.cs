using System;
using System.Collections.Generic;
using System.IO;

namespace DependencyAndMoqExcerise
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> testGroup = new Dictionary<string, List<string>>()
            {
                {"Testing", new List<string>() { "Name1","Testing2" }},
                {"Testing2", new List<string>() { "Name2","Name3" }}

            };
            Groups groups = new Groups(testGroup);

           var list = groups.GetGroup("Testing");
             }
    }
}
